using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication_EProject.Models.NhanVienModel;

namespace WebApplication_EProject.Models.Request
{
	public class Request
	{
		[Key]
		public int Request_Id { get; set; }

		[Display(Name = "Nhân viên: ")]
		[Editable(false)]
		public int? Employee_ID { get; set; }

		[Display(Name = "Phòng ban")]
		[Editable(false)]
		public int? Role_ID { get; set; }

		[Required(ErrorMessage = "Yêu cầu phải có tên sản phẩm mà bạn muốn chọn")]
		[Display(Name = "Mặt hàng")]
		public int? productID { get; set; }

		[Required(ErrorMessage = "Yêu cầu phải có đơn vị tính sản phẩm mà bạn muốn chọn")]
		[Display(Name = "Đơn vị tính(hộp/cái/chiếc)")]
		[StringLength(maximumLength: 10, ErrorMessage = "Yêu cầu phải nhập độ dài kí tự đến 10")]
		public String Unit { get; set; }

		[Required(ErrorMessage = "Yêu cầu phải có số lượng sản phẩm mà bạn cần")]
		[Display(Name = "Số lượng sản phẩm")]
		[Range(minimum: 1, maximum: 1000, ErrorMessage = "Số lượng phải có từ 1 đến 1000")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Yêu cầu phải có giá sản phẩm mà bạn cần")]
		[Display(Name = "Đơn giá")]
		[Range(minimum: 0, maximum: 10000000, ErrorMessage = "Giá sản phẩm phải có từ 1 đến 10000000 đồng")]
		public long Price { get; set; }

		[Required(ErrorMessage = "Yêu cầu phải ghi rõ mục đích mà bạn cần")]
		[Display(Name = "Mục đích")]
		[StringLength(maximumLength: 25, MinimumLength = 4, ErrorMessage = "Yêu cầu phải nhập độ dài kí tự từ 4 đến 25")]
		public String Purpose { get; set; }

		[Display(Name = "Thời gian Yêu cầu")]
		[Editable(false)]
		public DateTime DateAdd { get; set; }

		[Editable(false)]
		[Display (Name = "Trạng thái")]
		public int Status { get; set; }

		
		[Editable(false)]
		[Display(Name = "Tạm hoãn")]
		public bool Pause { get; set; }

		[StringLength(maximumLength: 50, ErrorMessage = "Không được nhập quá 50 kí tự")]
		[Display(Name = "Ghi chú")]
		public String Note { get; set; }

		public virtual NhanVien NhanVien { get; set; }
		public virtual Role Role { get; set; }
		public virtual VanPhongPham VanPhongPham { get; set; }

		public ICollection<Log> Log { get; set; }
	}
}