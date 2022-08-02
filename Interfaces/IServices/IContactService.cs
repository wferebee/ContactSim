using ContactSim.Models;

namespace ContactSim.Interfaces.IServices
{
    public interface IContactService
    {
        IEnumerable<ContactResponse> FindAll();

        int Insert(Contact c);

        ContactResponse FindById(int id);

        bool Delete(int id);

        bool UpdateContact(Contact contact);

        IEnumerable<CallListMember> GenerateCallList();
    }
}
