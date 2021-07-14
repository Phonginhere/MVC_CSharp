using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Info.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage ="Please input")]
        
        public String StudentName { get; set; }

        [Required(ErrorMessage = "Please input")]
        [DataType(DataType.DateTime)]
        public System.DateTime BirthOfDate { get; set; }

        [Required(ErrorMessage = "Please input")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Please input")]
        [Display(Name = "Upload image")]
        [DataType(DataType.Upload)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.jpg)$", ErrorMessage ="Required .jpg image")]
        public String Picture { get; set; }
    }
}