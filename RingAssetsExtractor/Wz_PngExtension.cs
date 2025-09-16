using System.Drawing;
using System.Drawing.Imaging;
using WzComparerR2.WzLib;

namespace RingAssetsExtractor;

public static class Wz_PngExtension
{
    /// <summary>
    /// Extracts and saves the PNG image to the specified file path.
    /// </summary>
    public static void SaveToPng(this Wz_Png wzPng, string filePath, int page = 0)
    {
        using Bitmap bitmap = wzPng.ExtractPng(page);
        bitmap.Save(filePath, ImageFormat.Png);
    }
}