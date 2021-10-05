using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Blog_Only.Models
{
	public class Blog
	{
		[Key]
		public int BlogId { get; set; }

		[Required]
		public int BlogName { get; set; }

		[Required]
		public int BlogDetails { get; set; }

		[Required]
		public List<string> Tags { get; set; }

		[Required]
		public DateTime CreateTime { get; set; }

		[Required]
		public DateTime EditTime { get; set; }

	}
}