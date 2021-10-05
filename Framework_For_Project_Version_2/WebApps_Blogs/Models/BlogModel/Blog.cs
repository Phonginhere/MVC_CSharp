using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApps_Blogs.Models.BlogModel
{
	public class Blog
	{
		[Key]
		public int BlogId { get; set; }

		[Required]
		public String BlogName { get; set; }

		[AllowHtml]
		public String BlogContent { get; set; }

		public String BlogTag { get; set; }

		[Editable(false)]
		public DateTime BlogEdited { get; set; }

		[Editable(false)]
		public DateTime BlogCreated { get; set; }

	}
}