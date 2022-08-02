using LiteDB;
using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class ContactResponse : Contact
    {
        [BsonId]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public new int Id { get; set; }

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
