namespace ContactSim.Models
{
    public class CallListMember : Contact
    {
        public Name MemberName { get; set; }
        public string HomePhone { get; set; }

        public CallListMember(Contact contact)
        {
            MemberName = contact.NameInfo;
            HomePhone = contact.PhoneInfo.Where(x => x.PhoneType == "home").Select(x => x.PhoneNumber.ToString()).FirstOrDefault();
        }
    }
}
