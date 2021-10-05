using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Blog_Ver2.Models.Admin
{
	public class Role
	{
		[Key]
		public int RoleId { get; set; }

		[Display(Name = "Role Name")]
		[Required(ErrorMessage = "Please input Role Name")]
		[StringLength(maximumLength: 20, ErrorMessage = "Please input role name from 2 to 20", MinimumLength = 2)]
		public string RoleName { get; set; }

		public virtual ICollection<EmployeeRoleMapping> EmployeeRoleMappings { get; set; }
	}
}