using LiteDB;
using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class ContactResponse : Contact
    {
        // Need the ID to be returned with responses, so we are marking it as Never Ignore
        [BsonId]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public new int Id { get; set; }
    }
}
