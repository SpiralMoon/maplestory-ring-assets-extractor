using Newtonsoft.Json;

namespace RingAssetsExtractor
{
    /// <summary>
    /// Json schema
    /// </summary>
    public class Output
    {
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

        [JsonProperty("slices")]
        public Dictionary<string, Slice> Slices { get; set; } = new Dictionary<string, Slice>();
    }

    public class Slice
    {
        [JsonProperty("origin")]
        public Origin Origin { get; set; } = new Origin();
    }

    public class Origin
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
}
