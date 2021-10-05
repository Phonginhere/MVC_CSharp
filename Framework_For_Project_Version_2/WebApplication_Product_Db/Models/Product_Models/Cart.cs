using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Product_Db.Models.Product_Models
{
	public class Cart
	{
		[Key]
		public int CartId { get; set; }

		public String CartName { get; set; }

		public long CartQuantity { get; set; }

		[DataType(DataType.Currency)]
		public long CartPrice { get; set; }

		public String CartCmt { get; set; }

		public int ProductId { get; set; }

		public virtual Product Product { get; set; }
	}

}