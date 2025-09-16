using Microsoft.Extensions.Configuration;
using RingAssetsExtractor;


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
