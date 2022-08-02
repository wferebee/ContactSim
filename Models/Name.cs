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
    }
}
