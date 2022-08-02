using ContactSim.Interfaces.IServices;
using ContactSim.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactSim.Controllers
{
    //Had to make this controller becasue ContactControler doesnt like that I am using CallListMember Model - this was quickest fix
    // - changed the routing to still show api/contacts/call-list though
    [Route("api/contacts/call-list")]
    [ApiController]
    public class CallListMemberController : ControllerBase
    {
        private readonly IContactService _contactService;

        public CallListMemberController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CallListMember>> GetCallList()
        {
            IEnumerable<CallListMember> contacts = _contactService.GenerateCallList();

            if (!contacts.Any())
            {
                return StatusCode(200, "No Content Found");
            }
            return Ok(contacts);
        }

    }
}
