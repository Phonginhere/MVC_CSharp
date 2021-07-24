using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_PrepareTest.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Nhập từ 2 đến 100", MinimumLength = 2)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Nhập từ 2 đến 20", MinimumLength = 2)]
        public string StudentRollId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StudentDOB { get; set; }

        [Required]
        public int ClassId { get; set; }


        public virtual ICollection<Exam> Exam { get; set; }
        public virtual Class Class { get; set; }
    }
}