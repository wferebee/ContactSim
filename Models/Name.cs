using LiteDB;

namespace ContactSim.Models
{
    public class Name
    {
        [BsonField("first")]
        public string First { get; set; }
        [BsonField("middle")]
        public string Middle { get; set; }
        [BsonField("last")]
        public string Last { get; set; }

        public Name(string first, string middle, string last)
        {
            First = first;
            Middle = middle;
            Last = last;
        }
    }
}
