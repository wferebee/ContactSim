using LiteDB;

namespace ContactSim.Models
{
    public class Address
    {
        [BsonField("street")]
        public string Street { get; set; }
        [BsonField("city")]
        public string City { get; set; }
        [BsonField("state")]
        public string State { get; set; }
        [BsonField("zip")]
        public int Zip { get; set; }

        public Address(string street, string city, string state, int zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}
