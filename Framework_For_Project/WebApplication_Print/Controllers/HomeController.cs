using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using WebApplication_Print.Models;

namespace WebApplication_Print.Controllers
{
	public class HomeController : Controller
	{
		private List<Employee> GetEmployees()
		{
			List<Employee> employees = new List<Employee>();
			employees.Add(new Employee { EId = 1, EName = "Maria", Gender = "Female", PNo = "030-0074321", Location = "Austria", Company = "Alfreds Futterkiste" });
			employees.Add(new Employee { EId = 2, EName = "Antonio Moreno", Gender = "Male", PNo = "(5) 555-3932", Location = "Brazil", Company = "Antonio Moreno Taquería" });
			employees.Add(new Employee { EId = 3, EName = "Thomas Hardy ", Gender = "Male", PNo = "(5) 555-3932", Location = "Ireland", Company = "Around the Horn" });

			return employees;
		}

		public ActionResult Index()
		{
			return View();
		}

        public JsonResult getAll()
        {
            return Json(GetEmployees(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GenerateReport(int eId)
        {
            string html = "";
            Employee employee = GetEmployees().Where(x => x.EId == eId).FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            // Company Logo and Name.
            html += "<div style='text-align:center;'>" +
                    "<img src='" + GetUrl("Files/Logo.png") + "' height='50px' width='100px' />" +
                    "<br/><h2>Excelasoft Solutions</h2><hr/>" +
                    "</div>";

            // Employee Data.
            html += "<table>" +
                    "<tr><th>Id</th><td colspan='2'> : " + employee.EId + "</td></tr>" +
                    "<tr><th>Name</th><td colspan='2'> : " + employee.EName + "</td></tr>" +
                    "<tr><th>Gender</th><td colspan='2'> : " + employee.Gender + "</td></tr>" +
                    "<tr><th>Phone No</th><td colspan='2'> : " + employee.PNo + "</td></tr>" +
                    "<tr><th>Location</th><td colspan='2'> : " + employee.Location + "</td></tr>" +
                    "<tr><th>Company</th><td colspan='2'> : " + employee.Company + "</td></tr>" +
                    "</table>";

            using (MemoryStream stream = new MemoryStream())
            {
                StringReader sr = new StringReader(html);
                Document pdfDoc = new Document(PageSize.A4, 50f, 10f, 30f, 10f);

                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                TempData["Data"] = stream.ToArray();
            }

            return new JsonResult() { Data = new { FileName = employee.EName.Trim().Replace(" ", "_") + ".pdf" } };
        }

        [HttpGet]
        public virtual ActionResult Download(string filename)
        {
            if (TempData["Data"] != null)
            {
                byte[] data = TempData["Data"] as byte[];
                return File(data, "application/pdf", filename);
            }
            else
            {
                return new EmptyResult();
            }
        }

        private string GetUrl(string imagePath)
        {
            string appUrl = System.Web.HttpRuntime.AppDomainAppVirtualPath;
            if (appUrl != "/")
            {
                appUrl = "/" + appUrl;
            }
            string url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, appUrl);

            return url + imagePath;
        }

        public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}