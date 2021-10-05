using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Product.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		public String ProductName { get; set; }

		public String ProductDetails { get; set; }

		[StringLength(maximumLength: 250, ErrorMessage = "Input from 2 to 250 characters", MinimumLength = 2)]
		[Display(Name = "Input Product Link Image")]
		[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Yêu cầu nhập đúng định dạng ảnh .png|.jpg|.gif")]
		public String productLinkImg { get; set; }

		public String productComment { get; set; }

		public double ProductPrice { get; set; }
	}
}