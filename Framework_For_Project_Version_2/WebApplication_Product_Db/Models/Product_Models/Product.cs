using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Product_Db.Models.Product_Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		public String ProductName { get; set; }

		[DataType(DataType.Currency)]
		public long ProductPrice { get; set; }

		public long ProductQuantity { get; set; }

		public String ProductCmt { get; set; }

		public virtual ICollection<Cart> Cart { get; set; }
	}
}