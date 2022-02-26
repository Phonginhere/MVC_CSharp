using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication_EProject.Models.NhanVienModel
{
	public class UserRoleProvider : RoleProvider
	{
		ModelContext db = new ModelContext();
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
			using (ModelContext _Context = new ModelContext())
			{
				var userRoles = (from user in _Context.NhanViens
								 join role in _Context.Roles
								 on user.Role_ID equals role.Role_ID
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