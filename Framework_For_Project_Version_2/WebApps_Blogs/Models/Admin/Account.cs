using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApps_Blogs.Models.Admin
{
	public class Account
	{
        [Key]
        public int AccountId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Please input Last Name from 2 to 50", MinimumLength = 2)]
        public string FullName { get; set; }

        //password
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
		[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-/=+]).{6,}$", ErrorMessage = "Password must contain at least: 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Special Characters and 1 Number")]
		public string Password { get; set; }

        [Required(ErrorMessage = "Please input email")]
        [RegularExpression(@"^([A-Za-z0-9_.]+)\@+(gmail|outlook|icloud|hotmail)*(.com|.uk|.vn|.us)$",
            ErrorMessage = "Wrong email form Ex: nameemail@gmail|outlook|icloud|hotmail.com|uk|vn|us")]
        public string Email { get; set; }

        public virtual ICollection<EmployeeRoleMapping> EmployeeRoleMapping { get; set; }
    }
}