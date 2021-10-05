using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_CodeFirst_Panel_4.Models
{
	public class Employee
	{
        public int EmployeeId { get; set; }

        //Image

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Please correct image path .png|.jpg|.gif")]
        [StringLength(maximumLength: 200, ErrorMessage = "Image path length name from 2 to 200", MinimumLength = 2)]
        public String Employee_Image { get; set; }

        //Full Name

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter Full Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Please input Full Name from 2 to 50", MinimumLength = 2)]
        public string FullName { get; set; }

        //password

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Password must have from 6 to 32 characters", MinimumLength = 6)]
        [RegularExpression(@"^([a-zA-Z0-9]{3,32})$",
            ErrorMessage = "Password must contain: At least 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number")]
        public string Password { get; set; }


        //Gender

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select the gender")]
        public string Gender { get; set; }

        //Email

        [Required(ErrorMessage = "Please input email")]
        [RegularExpression(@"^([A-Za-z0-9_.]+)\@+(gmail|outlook|icloud|hotmail)*(.com|.uk|.vn|.us)$",
            ErrorMessage = "Sai định dạng email VD: nameEmail@gmail|outlook|icloud|hotmail.com|uk|vn|us")]
        public string Email { get; set; }


        //Phone Number


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"(0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Please follow vietnamese +84 format")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "Input 10 to 11 characters")]
        public string PhoneNumber { get; set; }


        //Date of Birth

        [DataType(DataType.Date)]
        [Display(Name = "Date.Of.Birth")]
        [Required(ErrorMessage = "Date Required!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DOB { get; set; }

        //Salary

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please input salary")]
        [Range(minimum: 2, maximum: 999999, ErrorMessage = "Please input on the range of 1000 to 999999")]
        public int Salary { get; set; }

        //Date added

        [Editable(false)]
        [Display(Name = "Date Added")]
        public DateTime Date_Added { get; set; }

        //Date edited

        [Editable(false)]
        [Display(Name = "Date Edited")]
        public DateTime Date_Edited { get; set; }
    }
}