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
            // HomePhone gets populated with the Phone Number of the Home Phone
            // The Constructor will get called with Contacts that have already been filtered to have home phones
            HomePhone = contact.PhoneInfo.Where(x => x.PhoneType == "home").Select(x => x.PhoneNumber.ToString()).FirstOrDefault();
        }
    }
}
