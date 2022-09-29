using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using groups_backend.Models;

namespace groups_backend.Service
{
    public interface IGroupsService
    {
        //Users
        bool CreateUser(createUser NewUserData);
        List<users> GetUsers();
        users GetUserById(int userId);
        users GetUserByUsername(string username);
        result ChangePassword(changePassword changePassword);
        result ChangeUserStatus(int userId);
        bool SaveAuthorizationToken(string token, users user);

        //Members
        List<members> GetMembers();
        members GetMemberById(int memberId);
        result CreateMember(members member);
        result UpdateMemberProfile(members member);
        result ChangeMemberStatus(int memberId);

        //Projects
        List<projects> GetProjects();
    }
}
