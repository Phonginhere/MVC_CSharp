using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_EProject.Models.NhanVienModel
{
    public class ResetPass
    {
		[Key]
		[Display(Name = "ResetPass ID")]
		public int ResetPass_ID { get; set; }

		[Range(minimum: 100000, maximum: 999999)]
		public long PassCodeNum { get; set; }

		[Display(Name = "Employee ID")]
		public int? Employee_ID { get; set; }

		public virtual NhanVien NhanVien { get; set; }
	}
}