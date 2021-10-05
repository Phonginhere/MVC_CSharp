using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppication_Blog_Only.Models
{
	public class Blog
	{
		[Key]
		public int BlogId { get; set; }

		[Required]
		[Display(Name = "Blog Name")]
		public String BlogName { get; set; }

		[Required]
		[Display(Name = "Blog Details")]
		public String BlogDetails { get; set; }

		[Required]
		[Display(Name = "Tags")]
		public string Tags { get; set; }
	}
}