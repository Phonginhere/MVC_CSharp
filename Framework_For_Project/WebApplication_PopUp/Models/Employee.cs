using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_PopUp.Models
{
	public class Employee
	{
		[Key]
		public int Employee_Id { get; set; }

		public String Employee_Name { get; set; }

		public String Employee_Comment { get; set; }
	}
}