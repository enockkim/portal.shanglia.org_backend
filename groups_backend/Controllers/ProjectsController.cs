using groups_backend.Models;
using groups_backend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace groups_backend.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly ILogger<ProjectsController> _logger;
        private IGroupsService groupService;

        public ProjectsController(ILogger<ProjectsController> logger, IGroupsService _groupService)
        {
            _logger = logger;
            groupService = _groupService;
        }

        [HttpGet]
        public IEnumerable<projects> GetAllProjects()
        {
            return (IEnumerable<projects>)groupService.GetProjects();
        }
    }
}