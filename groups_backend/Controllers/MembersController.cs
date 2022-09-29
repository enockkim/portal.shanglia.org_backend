using groups_backend.Models;
using groups_backend.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace groups_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private IGroupsService groupService;

        public MembersController(ILogger<MembersController> logger, IGroupsService _groupService)
        {
            _logger = logger;
            groupService = _groupService;
        }

        // GET: api/<MembersController>
        [HttpGet("GetAllMembers")]
        public IEnumerable<members> GetAllMembers()
        {
            return (IEnumerable<members>)groupService.GetMembers();
        }

        // GET api/<MembersController>/5
        [HttpGet("GetMemberById")]
        public members Get(int memberId)
        {
            return groupService.GetMemberById(memberId);
        }

        // POST api/<MembersController>
        [HttpPost("RegisterMember")]
        public result Post([FromBody] members member)
        {
            return groupService.CreateMember(member);            
        }

        // PUT api/<MembersController>/5
        [HttpPut("UpdateMemberProfile")]
        public result Put([FromBody] members member)
        {
            return groupService.UpdateMemberProfile(member);
        }

        // DELETE api/<MembersController>/5
        [HttpPost("ChangeMemberStatus")]
        public result Delete(int memberId)
        {
            return groupService.ChangeMemberStatus(memberId);
        }
    }
}
