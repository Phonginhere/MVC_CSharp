using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApps_Blogs.Models.Admin
{
	public class EmployeeRoleMapping
	{
        [Key]
        public int MapId { get; set; }

        [Required(ErrorMessage = "Please having data")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Please having data")]
        public int RoleId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}