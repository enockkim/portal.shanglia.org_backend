using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace groups_backend.Models
{
    public class users
    {
        #region Properties
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int memberId { get; set; }
        public int status { get; set; }
        public DateTime dateOfCreation { get; set; }
        public int createdBy { get; set; }
        public string userRole { get; set; }
        #endregion    
    }

    public class createUser
    {
        public string userName { get; set; }
        public int memberId { get; set; }
        public int createdBy { get; set; }
    }

    public class userLoginData
    {
        public string testUsername { get; set; }
        public string testPassword { get; set; }
    }
    public class result
    {
        public bool status { get; set; }
        public string message { get; set; }
    }
    public class LoginResult
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
    public class changePassword
    {
        public int userId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }

    public class login_history
    {
        [Key]
        public int recordId { get; set; }
        public int userId { get; set; }
        public string token { get; set; }
        public DateTime dateOfLogin { get; set; }
    }
}