using ContactSim.Interfaces.IServices;
using ContactSim.Models;
using Microsoft.AspNetCore.Mvc;

namespace VirtualDirectory.Controllers
{
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

            return Ok(contacts);
        }

    }
}
