using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_PrepareTest.Models
{
    public class Class
    {
        public int ClassId { get; set; }

        [Required]
        [StringLength(maximumLength: 15, ErrorMessage = "Nhập từ 2 đến 15", MinimumLength = 2)]
        public String ClassName { get; set; }


        public virtual ICollection<Student> Student { get; set; }
    }
}