using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_CodeFirst_Panel_2.Models
{
	public class Contact
	{
		[Key]
		public int Contact_Id { get; set; }

		//full name contact
		[Display(Name = "Full Name")]
		[Required (ErrorMessage = "Please Input Full Name")]
		[StringLength(maximumLength: 50, ErrorMessage = "Full Name is required from 2 to 50", MinimumLength = 2)]
		public String Contact_Name { get; set; }

		//email
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Please Input Email")]
		[RegularExpression(@"^([A-Za-z0-9_.]+)\@+(gmail|outlook|icloud|hotmail)*(.com|.uk|.vn|.us)$",
			ErrorMessage = "Wrong email Example: tenEmail@gmail|outlook|icloud|hotmail.com|uk|vn|us")]
		public String Contact_Email { get; set; }

		
		//subject 
		[Display(Name = "Subject")]
		[Required(ErrorMessage = "Please Input Subject")]
		[StringLength(maximumLength: 100, ErrorMessage = "Subject is required from 2 to 100", MinimumLength = 2)]
		public String Contact_Subject { get; set; }

		//Body Message
		[Display(Name = "Body")]
		[Required(ErrorMessage = "Please Input Body Message")]
		[StringLength(maximumLength: 5000, ErrorMessage = "Body is required from 2 to 5000", MinimumLength = 2)]
		public String Contact_Body { get; set; }

		//check
		[Display(Name = "Done")]
		public bool Contact_Check { get; set; }

		[Editable(false)]
		public DateTime Contact_Date_Submit { get; set; }
	}
}