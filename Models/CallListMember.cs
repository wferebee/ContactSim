using System.Text.Json.Serialization;

namespace ContactSim.Models
{
    public class CallListMember
    {
        [JsonPropertyName("name")]
        public Name MemberName { get; set; }

        [JsonPropertyName("phone")]
        public string HomePhone { get; set; }

        public CallListMember(Contact contact)
        {
            MemberName = contact.NameInfo;
            HomePhone = contact.PhoneInfo.Where(x => x.PhoneType == "home").Select(x => x.PhoneNumber.ToString()).FirstOrDefault();
        }
    }
}
