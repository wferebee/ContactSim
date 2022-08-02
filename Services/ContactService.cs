using ContactSim.Interfaces.ILiteDbSetup;
using ContactSim.Interfaces.IServices;
using ContactSim.Models;
using LiteDB;


namespace ContactSim.Services
{
    public class ContactService : IContactService
    {
        #region DI Setup and Constructor
        private readonly ILiteDbContext _liteDbContext;
        private LiteDatabase _liteDb;

        public ContactService(ILiteDbContext liteDbContext)
        {
            _liteDbContext = liteDbContext;
            _liteDb = _liteDbContext.Database;
        }
        #endregion

        public IEnumerable<ContactResponse> FindAll()
        {

            return _liteDb.GetCollection<ContactResponse>("Contacts")
               .FindAll();
        }
        public ContactResponse FindById(int id)
        {
            return _liteDb.GetCollection<ContactResponse>("Contacts").Find(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(Contact c)
        {
            return _liteDb.GetCollection<Contact>("Contacts")
                .Insert(c);
        }

        public bool UpdateContact(Contact contact)
        {
            bool didUpdate = _liteDb.GetCollection<Contact>("Contacts")
           .Update(contact.Id, contact);
            return didUpdate;
        }

        public bool Delete(int id)
        {
            var contactToDelete = _liteDb.GetCollection<Contact>("Contacts").Find(x => x.Id == id).FirstOrDefault();
            if (contactToDelete != null)
            {
                return _liteDb.GetCollection<Contact>("Contacts").Delete(id);
            }
            return false;
        }

        public IEnumerable<CallListMember> GenerateCallList()
        {
            var callList = new List<CallListMember>();

            var contacts = _liteDb.GetCollection<Contact>("Contacts")
               .FindAll();

            var filteredContacts = from contact in contacts
                                   from nums in contact.PhoneInfo
                                   where nums.PhoneType == "home"
                                   orderby contact.NameInfo.Last, contact.NameInfo.First
                                   select new CallListMember(contact);

            foreach (var con in filteredContacts)
            {
                callList.Add(con);
            }

            return callList;
        }

    }
}
