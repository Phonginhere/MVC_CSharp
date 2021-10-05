using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Product_Db.Models.Product_Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }

		[Display(Name = "Tên khách hàng")]
		public String Order_CustomerName { get; set; }

		[Display(Name = "Số điện thoại")]
		[DataType(DataType.PhoneNumber)]
		public String Order_CustomerPhoneNum { get; set; }

		[Display(Name = "Địa chỉ")]
		public String Order_CustomerAddress { get; set; }

		[Editable(false)]
		public DateTime Order_Time { get; set; }

		public int Order_DetailId { get; set; }

		public virtual Order_Detail Order_Detail { get; set; }
	}
}