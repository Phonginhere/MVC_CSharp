using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication_EProject.Models;
using WebApplication_EProject.Models.NhanVienModel;
using WebApplication_EProject.Models.Request;

namespace WebApplication_EProject.Controllers
{
	public class HomeController : Controller
	{
		ModelContext db = new ModelContext();

		public void Statuscheck()
		{
			var account = User.Identity.GetUserName();
			var Check_Email = db.NhanViens.FirstOrDefault(x => x.Email == account);
			if (Check_Email.Status == 0)
			{
				ViewBag.haha = "Account currently disabled";
				FormsAuthentication.SignOut();
			}
		}

		[Authorize]
		public ActionResult Index(String Status_Check)
		{
			Statuscheck();
			var user = User.Identity.GetUserName();
			var check_user = db.NhanViens.FirstOrDefault(c => c.Email.Equals(user));
			int role_number = (int)check_user.Role_ID;

			//count other
			int count_employee = (from c in db.NhanViens select c.Employee_ID).Count();
			int count_stationery = (from s in db.VanPhongPhams select s.productID).Count();

			//request count:
			int count_request_huydon = (from c in db.Requests where c.Status == -2 select c).Count();
			int count_request_tuchoidon = (from c in db.Requests where c.Status == -1 select c).Count();

			int count_donhang_moitao = (from c in db.Requests where c.Status == 0 || c.Status == 1 select c).Count();
			int count_donhang_moitao_nhanvien = (from c in db.Requests where c.Status == 0 select c).Count();
			int count_request_vattu_muahang = (from c in db.Requests where c.Status == 5 select c).Count();

			//group by
			int group_by_gui_tien = (from r in db.Requests
									 where r.Status == 4
									 group r by new { r.Role.RoleName, r.VanPhongPham.productName, r.Unit, r.Price, r.Status, r.Pause, r.Note } into g
									 select new Group<string, Request>
									 {
										 KeyRole = g.Key.RoleName,
										 KeyProduct = g.Key.productName,
										 KeyUnit = g.Key.Unit,
										 KeyQuantity = g.Sum(l => l.Quantity).ToString(),
										 KeyPrice = g.Key.Price.ToString(),
										 KeyStatus = g.Key.Status.ToString(),
										 KeyPause = g.Key.Pause.ToString(),
										 KeyNote = g.Key.Note,
										 Values = g
									 }).Count();
			int group_by_need_epgia = (from r in db.Requests
										where r.Status == 2
									   group r by new { r.Role.RoleName, r.VanPhongPham.productName, r.Unit, r.Price, r.Status, r.Pause, r.Note } into g
									   select new Group<string, Request>
									   {
										   KeyRole = g.Key.RoleName,
										   KeyProduct = g.Key.productName,
										   KeyUnit = g.Key.Unit,
										   KeyQuantity = g.Sum(l => l.Quantity).ToString(),
										   KeyPrice = g.Key.Price.ToString(),
										   KeyStatus = g.Key.Status.ToString(),
										   KeyPause = g.Key.Pause.ToString(),
										   KeyNote = g.Key.Note,
										   Values = g
									   }).Count();

			int group_by_mua_hang = (from r in db.Requests
									 where r.Status == 5
									 group r by new { r.Role.RoleName, r.VanPhongPham.productName, r.Unit, r.Status, r.Pause, r.Note } into g
									 select new Group<string, Request>
									 {
										 KeyRole = g.Key.RoleName,
										 KeyProduct = g.Key.productName,
										 KeyUnit = g.Key.Unit,
										 KeyQuantity = g.Sum(l => l.Quantity).ToString(),
										 KeyPrice = g.Sum(l => l.Price).ToString(),
										 KeyStatus = g.Key.Status.ToString(),
										 KeyPause = g.Key.Pause.ToString(),
										 KeyNote = g.Key.Note,
										 Values = g
									 }).Count();
			int count_request_thanhvien_chua_layhang = (from c in db.Requests where c.Status == 7 select c).Count();
			int count_request_thanhvien_nhanhang = (from c in db.Requests where c.Status == 8 select c).Count();
			int count_request_tralaihang_cho_nhansu = (from c in db.Requests where c.Status == 9 select c).Count();
			int count_request_tralaihang = (from c in db.Requests where c.Status == 10 select c).Count();

			//display count employee to stationery
			ViewBag.count_employee = count_employee;
			ViewBag.count_stationery = count_stationery;

			//display count request:
			ViewBag.count_request_huydon = count_request_huydon;
			ViewBag.count_request_tuchoidon = count_request_tuchoidon;

			ViewBag.count_donhang_moitao = count_donhang_moitao;
			ViewBag.count_donhang_moitao_nhanvien = count_donhang_moitao_nhanvien;
			ViewBag.count_request_vattu_muahang = count_request_vattu_muahang;

			ViewBag.count_request_thanhvien_chua_layhang = count_request_thanhvien_chua_layhang;
			ViewBag.count_request_thanhvien_nhanhang = count_request_thanhvien_nhanhang;

			ViewBag.count_request_tralaihang_cho_nhansu = count_request_tralaihang_cho_nhansu;
			ViewBag.count_request_thanhvien_trahang = count_request_tralaihang;


			//display group by
			ViewBag.group_by_need_epgia = group_by_need_epgia;
			ViewBag.group_by_mua_hang = group_by_mua_hang;
			ViewBag.group_by_gui_tien = group_by_gui_tien;

			var requests = from r in db.Requests where r.Role_ID == role_number select r;

			//status check
			int n;
			bool isNumeric = int.TryParse(Status_Check, out n);

			if (Status_Check != null && isNumeric == true)
			{
				int check = Convert.ToInt32(Status_Check);
				requests = from r in db.Requests where r.Status.Equals(check) && r.Role_ID == role_number select r;
			}
			return View(requests);
		}

		public ActionResult Error_Nothing()
		{
			return View();
		}

		public ActionResult Login()
		{
			//begin cập nhật
			bool check_online = User.Identity.IsAuthenticated;
			if(check_online == true)
			{
				return RedirectToAction("Error_Nothing");
			}
			//end cập nhật
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(NhanVien user)
		{
			//kiểm tra nếu 1 trong 2 ô textbox ko nhập 
			if (user.MatKhau == null || user.Email == null)
			{
				ViewBag.haha = "Missing Email or Password";
			}
			else
			{
				
				var account = db.NhanViens.FirstOrDefault(x => x.Email == user.Email);

				if (account == null)
				{
					ViewBag.haha = "User Login Details Failed!!";
				}
				else
				{
					bool pass_user_check = BCrypt.Net.BCrypt.Verify(user.MatKhau, account.MatKhau);
					if (pass_user_check == false)
					{
						ViewBag.haha = "User Login Details Failed!!";
					}
					else
					{
						if (account.Status == 0)
						{
							ViewBag.haha = "Account currently disabled";
						}
						else
						{
							FormsAuthentication.SetAuthCookie(user.Email, false);
							return RedirectToAction("Index");
						}
					}
					
				}
				return View();
			}
			return View();
		}
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Login");
		}


		public ActionResult Forget()
		{
			if (TempData["err_wr_e"] != null)
			{
				ViewBag.err_wr_e = TempData["err_wr_e"];
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Forget(string email)
		{
			bool has = db.NhanViens.Any(cus => cus.Email == email);

			var emailcheck = db.NhanViens.SingleOrDefault(x => x.Email == email);
			if (has == false)
			{
				//insert into db with random number
				TempData["err_wr_e"] = "Wrong Email";
				return RedirectToAction("Forget");
			}else if(emailcheck.Employee_ID == 1)
			{
				TempData["err_wr_e"] = "Không được phép chính sủa tài khoản root";
				return RedirectToAction("Forget");
			}

			//create random number
			Random _random = new Random();
			int num = _random.Next(100000, 999999);

			//send email with token
			MailMessage Msg = new MailMessage();
			Msg.From = new MailAddress("eprojectaptech20@gmail.com", "The reseter");// replace with valid value
			Msg.Subject = "Recover Password";
			Msg.To.Add(email); //replace with correct values
			Msg.Body = "The Code for reset password is: " + num;
			Msg.IsBodyHtml = true;
			//Msg.Priority = MailPriority.High;
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;
			smtp.Credentials = new System.Net.NetworkCredential("eprojectaptech20@gmail.com", "<aptechloveproject17");// replace with valid value
			smtp.EnableSsl = true;
			smtp.Timeout = 20000;

			smtp.Send(Msg);

			// begin upload to db
			ResetPass ac = new ResetPass();
			ac.PassCodeNum = num;
			ac.Employee_ID = emailcheck.Employee_ID;
			db.ResetPasses.Add(ac);
			db.SaveChanges();
			// end upload to db

			TempData["check"] = email;
			return RedirectToAction("ResetByCode");
		}

		public ActionResult ResetByCode()
		{
			if (TempData["check"] != null)
			{
				ViewBag.check = TempData["check"];
			}
			if (TempData["err_wr_e"] != null)
			{
				ViewBag.err_wr_e = TempData["err_wr_e"];
			}
			return View();
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult ResetByCode(String email, String code)
		{
			try
			{
				long coden = Convert.ToInt64(code);
				bool has = db.ResetPasses.Any(cus => cus.PassCodeNum == coden);
				var codecheck = db.ResetPasses.SingleOrDefault(x => x.PassCodeNum == coden);

				if (has == false)
				{
					TempData["err_wr_e"] = "Wrong Code";
					return RedirectToAction("ResetByCode");

				}
				ResetPass resetpass = db.ResetPasses.Find(codecheck.ResetPass_ID);
				db.ResetPasses.Remove(resetpass);
				db.SaveChanges();
				TempData["email_see"] = email;

				return RedirectToAction("ResetPassword");
			}
			catch
			{
				TempData["err_wr_e"] = "Wrong Code";
				return RedirectToAction("ResetByCode");
			}


		}

		public ActionResult ResetPassword()
		{
			if (TempData["email_see"] != null)
			{
				ViewBag.email_see = TempData["email_see"];
			}
			return View();
		}

		String SqlCon = ConfigurationManager.ConnectionStrings["ModelContext"].ConnectionString;
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ResetPassword(String email, NhanVien nhanVien)
		{
			var emailcheck = db.NhanViens.SingleOrDefault(x => x.Email == email);

			string passwordHash = BCrypt.Net.BCrypt.HashPassword(nhanVien.MatKhau);

			SqlConnection con = new SqlConnection(SqlCon);
			string sqlQuery = "Update NhanViens set MatKhau = @MatKhau where Employee_ID = @Employee_ID";
			con.Open();
			SqlCommand cmd = new SqlCommand(sqlQuery, con);
			cmd.Parameters.AddWithValue("@MatKhau", passwordHash);
			cmd.Parameters.AddWithValue("@Employee_ID", emailcheck.Employee_ID);
			int check = cmd.ExecuteNonQuery();
			con.Close();
			if (check == 1)
			{
				TempData["Successful"] = "Insert Succesful";
				return RedirectToAction("Login");
			}
			return View();
		}

		//[Authorize(Roles = "Admin, Staff")]
		[Authorize]
		public ActionResult Account_Details()
		{
			Statuscheck();
			string email = User.Identity.GetUserName();
			if (email == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}
			int i = 0;
			i++;
			var dbEntry = db.NhanViens.FirstOrDefault(acc => acc.Email == email);

			if (dbEntry == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}
			return View(dbEntry);
		}

		// Get:
		//[Authorize(Roles = "Admin, Staff")]
		[Authorize]
		public ActionResult Edit()
		{
			Statuscheck();
			string email = User.Identity.GetUserName();
			if (email == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}
			var dbEntry = db.NhanViens.FirstOrDefault(acc => acc.Email == email);
			if (dbEntry == null)
			{
				return HttpNotFound();
			}
			// begin cập nhạt
			if (dbEntry.Employee_ID == 1)
			{
				return RedirectToAction("Index");
			}
			// end cập nhạt
			if (TempData["old_check"] != null)
			{
				ViewBag.old_check = TempData["old_check"];

			}
			return View(dbEntry);
		}

		// POST: 
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Employee_ID,Ten,Email,NgayTao,NgaySua,DOB,MatKhau,Role_ID")] NhanVien nhanVien)
		{
			Statuscheck();
			if (ModelState.IsValid)
			{
				//var nhanvien_check = db.NhanViens.Find(nhanVien.Employee_ID);
				var nhanvien_check = db.NhanViens.FirstOrDefault(x => x.Employee_ID == nhanVien.Employee_ID);


				string passwordHash = BCrypt.Net.BCrypt.HashPassword(nhanVien.MatKhau);

				//begin gán cho thuộc tính của đối tượng
				nhanVien.NgaySua = DateTime.Now;
				nhanVien.NgayTao = nhanvien_check.NgayTao;
				//begin gán cho thuộc tính của đối tượng

				var nhanvien_exist = new NhanVien
				{
					Employee_ID = nhanVien.Employee_ID,
					DOB = nhanVien.DOB,
					Email = nhanVien.Email,
					Ten = nhanVien.Ten,
					MatKhau = passwordHash,
					NgayTao = nhanVien.NgayTao,
					NgaySua = nhanVien.NgaySua,
					Role_ID = nhanVien.Role_ID
				};

				db.Entry(nhanvien_check).CurrentValues.SetValues(nhanvien_exist);
				//db.Entry(nhanvien_exist).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");

			}
			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", nhanVien.Role_ID);
			return View(nhanVien);
		}



		//public ActionResult About()
		//{
		//	ViewBag.Message = "Your application description page.";

		//	return View();
		//}

		//public ActionResult Contact()
		//{
		//	ViewBag.Message = "Your contact page.";

		//	return View();
		//}
	}
}