using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_CodeFirst_Panel_2.Models
{
	public class Employee
	{
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(maximumLength: 20, ErrorMessage = "Please input First Name from 2 to 20", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(maximumLength: 10, ErrorMessage = "Please input Last Name from 2 to 10", MinimumLength = 2)]
        public string LastName { get; set; }

        //password
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Password must have from 6 to 32 characters", MinimumLength = 6)]
        [RegularExpression(@"^([a-zA-Z0-9]{3,32})$",
            ErrorMessage = "Password must contain: At least 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number")]
        public string Password { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select the gender")]
        public string Gender { get; set; }

        [Required (ErrorMessage = "Please input email")]
        [RegularExpression(@"^([A-Za-z0-9_.]+)\@+(gmail|outlook|icloud|hotmail)*(.com|.uk|.vn|.us)$",
            ErrorMessage = "Sai định dạng email VD: tenEmail@gmail|outlook|icloud|hotmail.com|uk|vn|us")]
        [Remote("IsAlreadySigned", "Register", HttpMethod = "POST", ErrorMessage = "Email already exists in database.")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"(0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Please follow vietnamese +84 format")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "Input 10 to 11 characters")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date.Of.Birth")]
        [Required(ErrorMessage = "Date Required!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please input salary")]
        [Range(minimum: 1000, maximum: 999999, ErrorMessage = "Please input on the range of 1000 to 999999")]
        public Nullable<int> Salary { get; set; }

        [Editable(false)]
		public DateTime Date_Added { get; set; }

		[Required(ErrorMessage = "Please have data")]
        public Nullable<int> DeptId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<EmployeeRoleMapping> EmployeeRoleMappings { get; set; }
    }
}