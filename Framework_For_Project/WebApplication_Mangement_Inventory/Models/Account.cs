using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Mangement_Inventory.Models
{
	public class Account
	{
		[Key]
		public int Account_Id { get; set; }

		//first name
		[Required(ErrorMessage = "Please Enter FirstName")]
		[StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Input from 2 to 20")]
		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

		//last name 
		[Required(ErrorMessage = "Please enter LastName")]
		[StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Input from 2 to 10")]
		[Display(Name = "LastName")]
		public string LastName { get; set; }

		//password
		[Required(ErrorMessage = "Please enter password")]
		[DataType(DataType.Password)]
		[StringLength(32, ErrorMessage = "Password must have from 6 to 32 characters", MinimumLength = 6)]
		[RegularExpression(@"^([a-zA-Z0-9]{3,})$",
			ErrorMessage = "Password must contain: Minimum 6 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number")]
		public string Password { get; set; }

		////repass
		//[ReadOnly(true)]
		//[Display(Name = "Confirm password")]
		//[Required(ErrorMessage = "Please enter confirm password")]
		//[Compare("Password", ErrorMessage = "Confirm password doesn't match, Please Type again !")]
		//[DataType(DataType.Password)]
		//public string Confirmpwd { get; set; }

		//gender
		[Display(Name = "Gender")]
		[Required(ErrorMessage = "Please Select the gender")]
		public string Gender { get; set; }

		//email
		[Required]
		[RegularExpression(@"^([A-Za-z0-9_.]+)\@+(gmail|outlook|icloud|hotmail)*(.com|.uk|.vn|.us)$", ErrorMessage = "Sai định dạng email VD: tenEmail@gmail|outlook|icloud|hotmail.com|uk|vn|us")]
		public string Email { get; set; }

		//phone number
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone Number")]
		[Required(ErrorMessage = "Phone Number Required!")]
		[RegularExpression(@"(0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Please follow vietnamese +84 format")]
		[StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "Input 10 to 11 characters")]
		public string phoneNumber { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "D.O.B")]
		[Required(ErrorMessage = "Date Required!")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DOB { get; set; }
	}
}