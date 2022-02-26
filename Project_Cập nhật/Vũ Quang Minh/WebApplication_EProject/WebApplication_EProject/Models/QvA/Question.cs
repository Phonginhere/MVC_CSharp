
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication_EProject.Models.NhanVienModel;

namespace WebApplication_EProject.Models.QvA
{
    public class Question
    {

        [Key]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Hay Nhap")]
        [StringLength(maximumLength: 25, ErrorMessage = "Nhap tu 2 den 25 chuoi ki tu", MinimumLength = 2)]
        [Display(Name = "Nhap_ten_cau_hoi")]
        public string question_name { get; set; }

        [Required(ErrorMessage = "Hay Nhap")]
        [StringLength(maximumLength: 200, ErrorMessage = "Nhap tu 2 den 200 chuoi ki tu", MinimumLength = 2)]
        [Display(Name = "Nhap_chi_tiet_cau_hoi")]
        public string question_desc { get; set; }

       
        //[StringLength(maximumLength: 25, ErrorMessage = "Nhap tu 5 den 50 chuoi ki tu", MinimumLength = 2)]
        //[Display(Name = "Nhap duong dan anh")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Yeu cau nhap dung dinh dang anh .png| .jpg| .gif")]
        //public string question_img { get; set; }

        public int? Role_ID { get; set; }

        [Editable(false)]
        public DateTime question_date { get; set; }
        [Editable(false)]
        public DateTime question_edited { get; set; }

        [Editable(false)]
        public int? Employee_ID { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }

    }
}