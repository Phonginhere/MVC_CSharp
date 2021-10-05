using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_CodeFirst_Panel_2.Models
{
	public class Department
	{
		[Key]
		public int DeptId { get; set; }

		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Please input department name from 2 to 30", MinimumLength = 2)]
		public string DepartName { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
	}
}