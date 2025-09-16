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

Console.WriteLine("Done");