using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Product.Models
{
	public class Item
	{
		public Product Product { get; set; }

		public long Quantity { get; set; }

	}
}