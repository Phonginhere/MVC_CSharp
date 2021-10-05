using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_CodeFirst_Panel_2.Models
{
	public class EmployeeRoleMapping
	{
        [Key]
        public int MapId { get; set; }

        [Required(ErrorMessage = "Please having data")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please having data")]
        public int RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}