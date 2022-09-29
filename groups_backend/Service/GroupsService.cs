using groups_backend.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace groups_backend.Service
{
    public class GroupsService : IGroupsService
    {
        private readonly ServiceDbContext _serviceDbContext;
        private readonly IConfiguration _configuration;
        PasswordHasher passwordHasher = new PasswordHasher();

        public GroupsService(ServiceDbContext _ServiceDbContext, IConfiguration configuration)
        {
            _serviceDbContext = _ServiceDbContext;
            _configuration = configuration;
        }

        //users
        public bool CreateUser(createUser NewUserData)
        {
            users user = new users()
            {
                userName = NewUserData.userName,
                memberId = NewUserData.memberId,
                status = 1,
                createdBy = NewUserData.createdBy,
                dateOfCreation = DateTime.Now,
                password = passwordHasher.HashPassword("@Admin123")
            };

            try
            {
                var res = _serviceDbContext.Add<users>(user);
                _serviceDbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<users> GetUsers()
        {
            var users = _serviceDbContext.users
                            .ToList();
            return users;
        }

        public users GetUserById( int userId )
        {
            var user = _serviceDbContext.users
                            .Where(u => u.userId == userId)
                            .FirstOrDefault();
            return user;
        }
        public users GetUserByUsername(string username)
        {
            var user = _serviceDbContext.users
                            .Where(u => u.userName == username)
                            .FirstOrDefault();
            return user;
        }

        public result ChangePassword(changePassword changePassword)
        {
            result res = new result();
            try
            {
                var user = _serviceDbContext.users
                                .Where(u => u.userId == changePassword.userId)
                                .FirstOrDefault();
                user.password = passwordHasher.HashPassword(changePassword.newPassword);

                _serviceDbContext.SaveChanges();

                res.status = true;
                res.message = "Passwored changed succesfully";
            }catch (Exception ex)
            {
                res.status = false;
                res.message = "An error occured. Please try again";
            }

            return res;
        }

        public result ChangeUserStatus(int userId)
        {
            result res = new result();
            try
            {
                var user = _serviceDbContext.users
                            .Where(u => u.userId == userId)
                            .SingleOrDefault();
                user.status = user.status == 0 ? 1 : 0;
                _serviceDbContext.SaveChanges();
                
                res.status = true;
                res.message = user.status == 0 ? "User deactivated successfully." : "User activated successfully.";
            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = "An error occured. Please try again";
            }

            return res;
        }

        public bool SaveAuthorizationToken(string token, users user)
        {
            try
            {
                login_history login_History = new login_history()
                {
                    userId = user.userId,
                    token = token,
                    dateOfLogin = DateTime.Now
                };
                _serviceDbContext.Add<login_history>(login_History);
                _serviceDbContext.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //members
        public List<members> GetMembers()
        {
            var members = _serviceDbContext.members
                            .ToList();

            return members;
        }

        public members GetMemberById(int memberId)
        {
            return _serviceDbContext.members
                        .Where(m => m.mid == memberId)
                        .FirstOrDefault();                        
        }

        public result CreateMember(members member)
        {
            result result = new result();
            try
            {
                member.status = 1;
                var res = _serviceDbContext.Add<members>(member);
                _serviceDbContext.SaveChanges();

                result.status = true;
                result.message = "Member created successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result.status = false;
                result.message = "Error creating member. Please try again.";
            }
            return result;
        } 

        public result UpdateMemberProfile(members member)
        {
            result result = new result();
            try
            {
                var res = _serviceDbContext.Update<members>(member);
                _serviceDbContext.SaveChanges();

                result.status = true;
                result.message = "Profile updated successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result.status = false;
                result.message = "Error updating profile. Please try again.";
            }
            return result;
        }

        public result ChangeMemberStatus(int memberId)
        {
            result result = new result();
            try
            {
                var member = _serviceDbContext.members
                            .Where(u => u.mid == memberId)
                            .SingleOrDefault();
                member.status = member.status == 0 ? 1 : 0;
                _serviceDbContext.SaveChanges();

                result.status = true;
                result.message = member.status == 0 ? "Member deactivated successfully." : "Member activated successfully.";
            }
            catch (Exception ex)
            {
                result.status = false;
                result.message = "An error occured. Please try again";
            }

            return result;
        }

        //projects
        public List<projects> GetProjects()
        {
            var projects = _serviceDbContext.projects
                            .ToList();
            return projects;
        }
    }    
}

