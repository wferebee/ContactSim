using ContactSim.Interfaces.IServices;
using ContactSim.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactSim.Controllers
{
    #region DI, Setup, and Constructor
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        #endregion

        //Get All Contacts
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            IEnumerable<Contact> contacts = _contactService.FindAll();
            if (!contacts.Any())
            {
                return StatusCode(200, "No Content Found");
            }
            return Ok(contacts);
        }

        //Get Contact by ID
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            Contact foundContact = _contactService.FindById(id);
            if (foundContact == null)
            {
                return BadRequest();
            }
            return StatusCode(200, foundContact);
        }

        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            //Returns a Document ID
            var id = _contactService.Insert(contact);

            //Check for Document ID then find and return newly created Object
            if (id > 0)
                return StatusCode(200, _contactService.FindById(id));
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<Contact> Update(Contact updatedContact, int id)
        {
            var contact = _contactService.FindById(id);

            if (contact is null)
            {
                return NotFound();
            }

            //Contact Exists? then try to update it
            updatedContact.Id = contact.Id;
            bool didUpdate = _contactService.UpdateContact(updatedContact);

            if (!didUpdate) { return BadRequest(); }

            return StatusCode(200, _contactService.FindById(updatedContact.Id));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool didDelete = _contactService.Delete(id);

            if (!didDelete) { return BadRequest(); }

            return StatusCode(200, $"Contact with ID: {id} was successfully DELETED");
        }
        [HttpGet]
        [Route("call-list")]
        public ActionResult<IEnumerable<Contact>> GetCallList()
        {
            IEnumerable<CallListMember> contacts = _contactService.GenerateCallList();

            if (!contacts.Any())
            {
                return StatusCode(200, "No Content Found");
            }
            return Ok(contacts);
        }


        [HttpPost]
        [Route("seed-db")]
        public ActionResult<List<Contact>> SeedDB(List<Contact> contacts)
        {
            //Returns a Document ID
            List<int> createdIds = _contactService.SeedDB(contacts);

            List<ContactResponse> contactResponses = _contactService.FindAllById(createdIds);


            //Check for Document ID then find and return newly created Object
            if (contactResponses.Any())
            {
                return StatusCode(200, contactResponses);
            }

            else
                return BadRequest();
        }
    }
}
