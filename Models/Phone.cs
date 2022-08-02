using LiteDB;
using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class Phone
    {
        [JsonPropertyName("number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("type")]
        public string PhoneType { get; set; }
    }
}
