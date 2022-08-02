using LiteDB;
using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class Name
    {
        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("middle")]
        public string Middle { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
