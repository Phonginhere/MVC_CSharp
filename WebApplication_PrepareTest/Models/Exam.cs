using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_PrepareTest.Models
{
    public class Exam
    {
        public int ExamId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [Range(maximum: 100, minimum: 0, ErrorMessage = "Nhập điểm từ 0 đến 100")]
        public int Mark { get; set; }


        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}