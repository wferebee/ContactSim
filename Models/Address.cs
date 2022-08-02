using LiteDB;
using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("zip")]
        public int Zip { get; set; }
    }
}
