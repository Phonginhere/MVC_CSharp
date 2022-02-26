using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication_EProject.Models.QvA;
using WebApplication_EProject.Models.Request;

namespace WebApplication_EProject.Models.NhanVienModel
{
    public class Role
    {
        [Key]
        public int Role_ID { get; set; }

        [Required]
        [Display(Name = "Phòng ban")]
        [StringLength(maximumLength: 50)]
        public string RoleName { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public ICollection<Log> Log { get; set; }
    }
}