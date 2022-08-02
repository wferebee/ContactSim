using LiteDB;

namespace ContactSim.Models
{
    public class Phone
    {
        [BsonField("number")]
        public string PhoneNumber { get; set; }
        [BsonField("type")]
        public string PhoneType { get; set; }

        public Phone(string phoneNumber, string phoneType)
        {
            PhoneNumber = phoneNumber;
            PhoneType = phoneType;
        }
    }
}
