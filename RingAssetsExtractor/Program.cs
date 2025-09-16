using Microsoft.Extensions.Configuration;
using RingAssetsExtractor;
using WzComparerR2.WzLib;

Console.WriteLine("Start");

#region load configuration

// Load by appsettings.json
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .Build();

var settings = new AppSettings();
config.Bind(settings);

#endregion

#region initialize output directories

string outputDir = settings.Paths.OutputDirectory;
string  imagesDir = Path.Combine(outputDir, "images");

Directory.CreateDirectory(outputDir);
Directory.CreateDirectory(imagesDir);

Console.WriteLine("Initialize output directories...");

#endregion

string wzFilePath = settings.Paths.WzFilePath; // Base.wz file path
Wz_Structure wz = new Wz_Structure(); // Root WZ tree

#region open wz (source from WzComparerR2)

Console.WriteLine("Trying open Base.wz");

if (string.Equals(Path.GetExtension(wzFilePath), ".ms", StringComparison.OrdinalIgnoreCase))
{
    wz.LoadMsFile(wzFilePath);
}
else if (wz.IsKMST1125WzFormat(wzFilePath))
{
    wz.LoadKMST1125DataWz(wzFilePath);
    if (string.Equals(Path.GetFileName(wzFilePath), "Base.wz", StringComparison.OrdinalIgnoreCase))
    {
        string packsDir = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(wzFilePath)), "Packs");
        if (Directory.Exists(packsDir))
        {
            foreach (var msFile in Directory.GetFiles(packsDir, "*.ms"))
            {
                wz.LoadMsFile(msFile);
            }
        }
    }
}
else
{
    wz.Load(wzFilePath, true);
}

Console.WriteLine("Base.wz open complete.");

#endregion

Wz_File wzFile = wz.WzNode.GetNodeWzFile(); // Root WZ file

#region load images

Wz_Node imgNodeChatBalloon = wz.WzNode.FindNodeByPath("UI\\ChatBalloon.img");
Wz_Node imgNodeNameTag = wz.WzNode.FindNodeByPath("UI\\NameTag.img");
Wz_Node imgNodeString = wz.WzNode.FindNodeByPath("String\\Eqp.img");

Wz_Image imgChatBalloon = imgNodeChatBalloon.GetNodeWzImage();
Wz_Image imgNameTag = imgNodeNameTag.GetNodeWzImage();
Wz_Image imgString = imgNodeString.GetNodeWzImage();

imgChatBalloon.TryExtract();
imgNameTag.TryExtract();
imgString.TryExtract();

Console.WriteLine("UI\\ChatBalloon.img is Ready.");
Console.WriteLine("UI\\NameTag.img is Ready.");
Console.WriteLine("String\\Eqp.img is Ready.");

#endregion

#region filter only chatBalloon or nameTag by all equipment rings

// Valid ring equipment code ranges (only chatBalloon, nameTag rings)
List<(int, int)> ringEqpCodeRanges = new([
    (1112100, 1112299),
    (1115000, 1115999)
]);

Wz_Node nodeRing = wz.WzNode.FindNodeByPath("Character\\Ring");

List<Wz_Node> imgNodeRings = nodeRing.Nodes.Where((node) =>
{
    // ex) 01112100.img
    string imgName = node.Text;

    if (!imgName.EndsWith(".img") || imgName.Length != 12)
    {
        return false;
    }

    if (int.TryParse(imgName.Substring(0, 8), out int eqpCode))
    {
        return ringEqpCodeRanges.Any(group => group.Item1 <= eqpCode && eqpCode <= group.Item2);
    }

    return false;
}).ToList();

#endregion

Output output = new Output(); // json output schema

#region parse ring info and extract .png

Console.WriteLine("Ring parse start.");

try
{
    foreach (var imgNodeRing in imgNodeRings)
    {
        Wz_Image imgRing = imgNodeRing.GetValue<Wz_Image>();
        string ringEqpCode = imgRing.Name.Substring(0, 8); // ex) 01112100

        // Load
        if (imgRing.TryExtract())
        {
            Wz_Node nodeRingInfo = imgRing.Node.Nodes["info"]; // summary info node

            // icon node
            Wz_Node nodeIconRaw = nodeRingInfo.Nodes["iconRaw"];
            Wz_Node nodeIconRawCanvas = nodeIconRaw.GetLinkedSourceNode(wzFile);
            Wz_Png pngIconRaw = nodeIconRawCanvas.GetValue<Wz_Png>();

            // Extract and save to .png file
            pngIconRaw.SaveToPng(Path.Combine(imagesDir, $"{imgNodeRing.Text}.iconRaw.png"));

            Wz_Node nodeChatBalloon = nodeRingInfo.Nodes["chatBalloon"];
            Wz_Node nodeNameTag = nodeRingInfo.Nodes["nameTag"];

            bool isChatBalloon = false;
            bool isNameTag = false;
            int ringRefCode = 0; // ring ref eqpCode
            string type = null; // "ChatBalloon" or "NameTag"
            Wz_Node nodeRingGraphic = null;

            if (nodeChatBalloon != null)
            {
                isChatBalloon = true;
                ringRefCode = nodeChatBalloon.GetValue<int>();
                type = "ChatBalloon";
                nodeRingGraphic = imgChatBalloon.Node.Nodes[$"{ringRefCode}"];
            }

            if (nodeNameTag != null)
            {
                isNameTag = true;
                ringRefCode = nodeNameTag.GetValue<int>();
                type = "NameTag";
                nodeRingGraphic = imgNameTag.Node.Nodes[$"{ringRefCode}"];
            }

            // Skip rings without graphic info (default chat balloon, default imgName tag, etc.)
            if (nodeRingGraphic == null)
            {
                continue;
            }

            Ring ring = new Ring();
            ring.EqpCode = ringEqpCode;
            ring.Type = type;
            ring.RingCode = ringRefCode.ToString();

            // nameTag : w, c, e
            // chatBalloon : head, nw, n, ne, w, c, e, sw, s, se, arrow
            string[] sliceNodeNames = { "head", "nw", "n", "ne", "w", "c", "e", "sw", "s", "se", "arrow" };
            List<Wz_Node> nodeSlices = nodeRingGraphic
                .Nodes
                .Where(n => sliceNodeNames.Contains(n.Text))
                .ToList();

            foreach (Wz_Node nodeSlice in nodeSlices)
            {
                if (nodeSlice.GetValue<Wz_Png>() != null)
                {
                    Wz_Node nodeSliceCanvas = nodeSlice.GetLinkedSourceNode(wzFile);
                    Wz_Png pngSlice = nodeSliceCanvas.GetValue<Wz_Png>();

                    // Extract and save to .png file
                    pngSlice.SaveToPng(Path.Combine(imagesDir, $"{nodeSlice.FullPath.Replace("\\", ".")}.png"));
                }

                Slice slice = new();

                // Parse ring slice image vector
                foreach (Wz_Node nodeSliceProperty in nodeSlice.Nodes)
                {
                    var key = nodeSliceProperty.Text;
                    var vector = nodeSliceProperty.GetValue<Wz_Vector>();

                    if (key == "origin" && vector != null)
                    {
                        var x = vector.X;
                        var y = vector.Y;

                        Origin origin = new()
                        {
                            X = x,
                            Y = y
                        };

                        slice.Origin = origin;
                    }
                }

                ring.Slices.Add(nodeSlice.Text, slice);
            }
            
            // Parse ring text color
            Wz_Node nodeClr = nodeRingGraphic.Nodes["clr"];
            string color = $"#{nodeClr.GetValue<int>():X6}"; // Convert integer to RGB hex

            // Parse ring imgName, description
            Wz_Node nodeRingString = imgString.Node.FindNodeByPath($"Eqp\\Ring\\{int.Parse(ringEqpCode)}");
            string name = nodeRingString.Nodes["name"]?.GetValue<string>() ?? "";
            string desc = nodeRingString.Nodes["desc"]?.GetValue<string>() ?? "";

            ring.Color = color;
            ring.Name = name;
            ring.Description = desc;

            output.Rings.Add(ring);

            Console.WriteLine($"Ring {ringEqpCode} parse completed.");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception occured.");
    Console.WriteLine(e);

    return;
}

Console.WriteLine("Ring parse finished.");

#endregion

#region write ring.json

string jsonOutputPath = Path.Combine(outputDir, "ring.json");

using (var writer = new StreamWriter(jsonOutputPath))
{
    var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);
    writer.Write(jsonStr);

    Console.WriteLine($"Ring data exported to {jsonOutputPath}");
}

#endregion

Console.WriteLine("Done");