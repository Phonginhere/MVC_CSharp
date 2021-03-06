using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication_Blog_Ver2.Models.Admin
{
	public class UserRoleProvider : RoleProvider
	{
		Blog_Ctx db = new Blog_Ctx();
		public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
			using (Blog_Ctx _Context = new Blog_Ctx())
			{
				var userRoles = (from user in _Context.Employees
								 join roleMapping in _Context.EmployeeRoleMappings
								 on user.EmployeeId equals roleMapping.MapId
								 join role in _Context.Roles
								 on roleMapping.RoleId equals role.RoleId
								 where user.Email == username
								 select role.RoleName).ToArray();
				return userRoles;
			}
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