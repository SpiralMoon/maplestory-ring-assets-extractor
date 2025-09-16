namespace RingAssetsExtractor;

public class AppSettings
{
    public PathSettings Paths { get; set; } = new PathSettings();
}

public class PathSettings
{
    public string WzFilePath { get; set; } = string.Empty;
    public string OutputDirectory { get; set; } = string.Empty;
}