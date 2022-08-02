using LiteDB;
using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class ContactResponse : Contact
    {
        [BsonId]
        [BsonField("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }

        [BsonField("name")]
        public Name NameInfo { get; set; }
        [BsonField("adress")]
        public Address AddressInfo { get; set; }
        [BsonField("phone")]
        public Phone[] PhoneInfoArray { get; set; } = new Phone[3];
        [BsonField("email")]
        public string Email { get; set; }


    }
}
