using LiteDB;
using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class Contact
    {
        //Base Class for Contact Response - Could be Base CLass for CallListMembers too
        [BsonId]
        [JsonIgnore]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public Name NameInfo { get; set; }

        [JsonPropertyName("address")]
        public Address AddressInfo { get; set; }

        [JsonPropertyName("phone")]
        public Phone[] PhoneInfo { get; set; } = new Phone[3];

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
