using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Security;

namespace GYM4UApp.Models
{
    public class UsersRoleProvider : RoleProvider
    {

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            //using (EmployeeDBContext context = new EmployeeDBContext())
            //{
            //    var userRoles = (from user in context.Users
            //                     join roleMapping in context.UserRolesMappings
            //                     on user.ID equals roleMapping.UserID
            //                     join role in context.RoleMasters
            //                     on roleMapping.RoleID equals role.ID
            //                     where user.UserName == username
            //                     select role.RollName).ToArray();
            //    return userRoles;
            //}
            //string[] userRoles = new string[] { "SuperAdmin" };
            //Console.WriteLine("asd", userRoles);
            //return userRoles;
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}