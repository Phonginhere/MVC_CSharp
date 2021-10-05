using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApps_Blogs.Models.BlogModel
{
	public class Tag
	{
		[Key]
		public int TagId { get; set; }
		public String TagName { get; set; }

	}
}