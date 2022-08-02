using ContactSim.Interfaces.IServices;
using ContactSim.Models;
using Microsoft.AspNetCore.Mvc;

namespace VirtualDirectory.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

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
        public ActionResult<Contact> Post(Contact dto)
        {
            var id = _contactService.Insert(dto);
            if (id > 0)
                return StatusCode(200, _contactService.FindById(dto.Id));
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



    }
}
