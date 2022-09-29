using Microsoft.AspNetCore.Mvc;
using groups_backend.Models;
using groups_backend.Service;
using System.Text.Json;
using Microsoft.AspNet.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace groups_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IGroupsService groupService;

        private PasswordHasher passwordHasher = new PasswordHasher();
        public UsersController(ILogger<UsersController> logger, IGroupsService _groupService)
        {
            _logger = logger;
            groupService = _groupService;
        }

        // GET: api/<UserController>
        [HttpGet("GetAllUsers")]
        public IEnumerable<users> Get()
        {
            return (IEnumerable<users>)groupService.GetUsers();
        }
         
        // GET api/<UserController>/5
        [HttpGet("GetUserById/{id}")]
        public users Get(int id)
        {
            return groupService.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost("CreateUser")]
        public bool Post([FromBody] createUser NewUserData)
        {
            return groupService.CreateUser(NewUserData);
        }

        // POST api/<UserController>
        [HttpPost("VerifyLoginData")]
        public LoginResult VerifyLoginData([FromBody] userLoginData userLoginData)
        {
            LoginResult result = new LoginResult();
            try
            {
                var user = groupService.GetUserByUsername(userLoginData.testUsername);
                if(user == null)
                {
                    result.status = false;
                    result.message = "Incorrect username or password.";
                }
                else if(user.status == 0)
                {
                    result.status = false;
                    result.message = "Account deactivated. Contact system administrator for assistance.";
                }
                else
                {
                    var res = passwordHasher.VerifyHashedPassword(user.password, userLoginData.testPassword);

                    if (res.ToString() == "Success")
                    {
                        result.status = true;
                        result.message = "Success";
                        result.token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                        groupService.SaveAuthorizationToken(result.token, user);
                    }
                    else
                    {
                        result.status = false;
                        result.message = "Incorrect username or password.";
                    }
                }  
            }
            catch(Exception ex)
            {
                result.status = false;
                result.message = "An error occured. Please try again.";
            }

            return result;
        }

        // PUT api/<UserController>/5
        [HttpPut("ChangePasword")]
        public result Put([FromBody] changePassword changePassword)
        {
            result res = new result();
            var user = groupService.GetUserById(changePassword.userId);
            var verifyPassword = passwordHasher.VerifyHashedPassword(user.password, changePassword.oldPassword);

            if (verifyPassword.ToString() == "Success")
            {
                var rea = groupService.ChangePassword(changePassword);
                user.password = changePassword.newPassword;

                res = groupService.ChangePassword(changePassword);
            }
            else
            {
                res.status = false;
                res.message = "Incorrect password.";
            }

            return res;
        }

        // DELETE api/<UserController>/5
        [HttpPut("ChangeUserStatus")]
        public result ChangeUserStatus(int userId)
        {
            return groupService.ChangeUserStatus(userId);
        }
    }
}
