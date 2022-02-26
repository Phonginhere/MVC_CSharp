using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_EProject.Models.Request
{
    public class VanPhongPham
    {
        [Key]
        public int productID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        [Display(Name = "Tên mặt hàng")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Yêu cầu phải nhập độ dài kí tự từ 3 đến 50")]
        public string productName { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập nhà phân phối")]
        [Display(Name = "Tên nhà Phân phối")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "Yêu cầu phải nhập độ dài kí tự từ 6 đến 50")]
        public string producer { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Yêu cầu nhập từ 2 to 50 kí tự cho file", MinimumLength = 2)]
        [Display(Name = "Đường dẫn ảnh")]
        public string productImage { get; set; }

        public ICollection<Request> Request { get; set; }
    }
}
