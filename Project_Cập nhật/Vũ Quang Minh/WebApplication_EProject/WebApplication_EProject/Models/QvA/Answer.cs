using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication_EProject.Models.NhanVienModel;

namespace WebApplication_EProject.Models.QvA
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required(ErrorMessage = "Hay Nhap")]
        [StringLength(maximumLength: 200, ErrorMessage = "Nhap tu 2 den 200 chuoi ki tu", MinimumLength = 2)]
        [Display(Name = "Nhap_cau_tra_loi")]
        public string answer_question { get; set; }

        public DateTime answer_date { get; set; }

        [Editable(false)]
        public int? Employee_ID { get; set; }

        [Editable(false)]
        public int? QuestionId { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Question Question { get; set; }
    }
}