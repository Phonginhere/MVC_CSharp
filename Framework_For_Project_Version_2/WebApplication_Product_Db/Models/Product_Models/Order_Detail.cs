using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Product_Db.Models.Product_Models
{
	public class Order_Detail
	{
		[Key]
		public int Order_DetailId { get; set; }

		public String Order_DetailName { get; set; }

		public long Order_DetailQuantity { get; set; }

		[DataType(DataType.Currency)]
		public long Order_DetailPrice { get; set; }

		public virtual ICollection<Order> Order { get; set; }
	}
}