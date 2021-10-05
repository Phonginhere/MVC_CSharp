using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Blog.Models.Admin
{
	public class Account
	{
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Please input Last Name from 2 to 50", MinimumLength = 2)]
        public string FullName { get; set; }

        //password
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Password must have from 6 to 32 characters", MinimumLength = 6)]
        [RegularExpression(@"^([a-zA-Z0-9]{3,32})$",
            ErrorMessage = "Password must contain: At least 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please input email")]
        [RegularExpression(@"^([A-Za-z0-9_.]+)\@+(gmail|outlook|icloud|hotmail)*(.com|.uk|.vn|.us)$",
            ErrorMessage = "Sai định dạng email VD: tenEmail@gmail|outlook|icloud|hotmail.com|uk|vn|us")]
        public string Email { get; set; }
    }
}