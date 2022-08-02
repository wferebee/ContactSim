using ContactSim.Interfaces.ILiteDbSetup;
using ContactSim.Interfaces.IServices;
using ContactSim.Models;
using LiteDB;


namespace ContactSim.Services
{
    public class ContactService : IContactService
    {
        #region DI, Setup, and Constructor
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
            // Get Contact where ID matches
            return _liteDb.GetCollection<ContactResponse>("Contacts").Find(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(Contact c)
        {
            return _liteDb.GetCollection<Contact>("Contacts")
                .Insert(c);
        }

        public bool UpdateContact(Contact contact)
        {
            bool didUpdate = _liteDb.GetCollection<Contact>("Contacts").Update(contact.Id, contact);
            return didUpdate;
        }

        public bool Delete(int id)
        {
            //Find Contact first
            var contactToDelete = _liteDb.GetCollection<Contact>("Contacts").Find(x => x.Id == id).FirstOrDefault();

            //If Contact Exists then delete it
            if (contactToDelete != null)
            {
                return _liteDb.GetCollection<Contact>("Contacts").Delete(id);
            }
            return false;
        }

        public IEnumerable<CallListMember> GenerateCallList()
        {
            //CallListMember Class only has some of the properties of the full COntact Class
            // We only need to return Name info and Home Phone Number
            var callList = new List<CallListMember>();

            // Add all contacts to a list to then query - would like to query the DB instead of creating a list of all the Contacts first
            var contacts = _liteDb.GetCollection<Contact>("Contacts")
               .FindAll();

            var filteredContacts = from contact in contacts
                                   from nums in contact.PhoneInfo
                                   where nums.PhoneType == "home"
                                   orderby contact.NameInfo.Last, contact.NameInfo.First // ordering by lastname and then firstname
                                   select new CallListMember(contact);

            //add filtered list to our CallListMembers List "callList"
            foreach (var con in filteredContacts)
            {
                callList.Add(con);
            }

            return callList;
        }

        public List<int> SeedDB(List<Contact> contacts)
        {
            List<int> createdIds = new();
            var col = _liteDb.GetCollection<Contact>("Contacts");

            foreach (var contact in contacts)
            {
                int temp = col.Insert(contact);
                createdIds.Add(temp);
            }
            return createdIds;
        }

        public List<ContactResponse> FindAllById(List<int> ids)
        {
            List<ContactResponse> createdContacts = new();

            foreach (var c in ids)
            {
                if (c > 0)
                {
                    var createdContact = FindById(c);
                    createdContacts.Add(createdContact);
                }
            }
            return createdContacts;
        }
    }
}
