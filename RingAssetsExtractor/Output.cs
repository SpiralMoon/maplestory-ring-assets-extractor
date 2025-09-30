using Newtonsoft.Json;

namespace RingAssetsExtractor
{
    /// <summary>
    /// Json schema
    /// </summary>
    public class Output
    {
        [JsonProperty("rings")]
        public List<Ring> Rings { get; set; } = new List<Ring>();
    }

    public class Ring
    {
        [JsonProperty("eqp_code")]
        public string EqpCode { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("ring_code")]
        public string RingCode { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("desc")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("color")]
        public string Color { get; set; } = string.Empty;

        [JsonProperty("is_animation")]
        public bool IsAnimation { get; set; } = false;

        [JsonProperty("height_offset")]
        public int? HeightOffset { get; set; }

        [JsonProperty("bottom_offset")]
        public int? BottomOffset { get; set; }

        [JsonProperty("images")]
        public Dictionary<string, object> Images { get; set; } = new Dictionary<string, object>();
    }

    public class ImageData
    {
        [JsonProperty("origin")]
        public Origin Origin { get; set; } = new Origin();

        [JsonProperty("size")]
        public Size Size { get; set; } = new Size();
    }

    public class Origin
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
    public class Size
    {
        [JsonProperty("w")]
        public int Width { get; set; }

        [JsonProperty("h")]
        public int Height { get; set; }
    }
}
