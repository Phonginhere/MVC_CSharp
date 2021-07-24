using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_PrepareTest.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Nhập từ 2 đến 100", MinimumLength = 2)]
        public String SubjectName { get; set; }


        public virtual ICollection<Exam> Exam { get; set; }
    }
}