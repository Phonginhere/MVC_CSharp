using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_Blog_Type.Models
{
	public class Blog
	{
		[Key]
		public int Blog_Id { get; set; }

		[Display(Name = "Blog Name")]
		[Required (ErrorMessage = "Please input")]
		[StringLength(maximumLength: 70, MinimumLength = 2, ErrorMessage = "Please Input from 2 to 70 length")]
		public string Blog_Name { get; set; }

		[AllowHtml]
		[Display(Name = "Blog Details")]
		[Required(ErrorMessage = "Please input")]
		public string Blog_Details { get; set; }
	}
}