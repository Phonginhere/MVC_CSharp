using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication_EProject.Models;
using WebApplication_EProject.Models.NhanVienModel;

namespace WebApplication_EProject.Controllers.NhanVienController
{
	[Authorize]
	public class NhanViensController : Controller
	{
		private ModelContext db = new ModelContext();

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
		// GET: NhanViens
		public ActionResult Index(string Status, string Role_ID, string SearchString)
		{
			Statuscheck();
			var item = from a in db.NhanViens select a;
			if (Role_ID == null || Status == null || SearchString == null)
			{
				goto jump; //nhảy
			}

			if (Role_ID != "" && SearchString != "" && Status != "")
			{
				int check_Stat = Convert.ToInt32(Status);
				int check_role = Convert.ToInt32(Role_ID);
				var nhanviens = from r in db.NhanViens
								where r.Role_ID == check_role
		 && (r.Ten.Contains(SearchString) || r.Email.Contains(SearchString))
		 && r.Status == check_Stat
								select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(nhanviens.ToList());
			}
			else if (Role_ID != "" && SearchString != "")
			{
				int check_role = Convert.ToInt32(Role_ID);
				var nhanviens = from r in db.NhanViens
								where r.Role_ID == check_role
								&& (r.Ten.Contains(SearchString) || r.Email.Contains(SearchString))
								select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(nhanviens.ToList());
			}
			else if (Status != "" && SearchString != "")
			{
				int check_Stat = Convert.ToInt32(Status);
				var nhanviens = from r in db.NhanViens
								where (r.Ten.Contains(SearchString) || r.Email.Contains(SearchString))
								 && r.Status == check_Stat
								select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(nhanviens.ToList());
			}
			else if (Status != "" && Role_ID != "")
			{
				int check_Stat = Convert.ToInt32(Status);
				int check_role = Convert.ToInt32(Role_ID);
				var nhanviens = from r in db.NhanViens
								where r.Role_ID == check_role
								 && r.Status == check_Stat
								select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(nhanviens.ToList());
			}


			if (Role_ID != "") //lọc phòng ban
			{
				int check_role = Convert.ToInt32(Role_ID);
				var nhanviens = from r in db.NhanViens where r.Role_ID == check_role select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(nhanviens.ToList());
			}
			else if (SearchString != "")
			{
				var nhanviens = from r in db.NhanViens
								where r.Ten.Contains(SearchString) || r.Email.Contains(SearchString)
								select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(nhanviens.ToList());
			}
			else if (Status != "") //lọc
			{
				int check_Stat = Convert.ToInt32(Status);
				var nhanviens = from r in db.NhanViens where r.Status == check_Stat select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(nhanviens.ToList());
			}
		jump:

			if (TempData["Alert"] != null)
			{

				ViewBag.Alert = TempData["Alert"];
			}
			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
			return View(item);
		}

		// GET: NhanViens/Details/5
		public ActionResult Details(int? id)
		{
			Statuscheck();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NhanVien nhanVien = db.NhanViens.Find(id);
			if (nhanVien == null)
			{
				return HttpNotFound();
			}
			return View(nhanVien);
		}

		//CREATE------------------------------------------------------------------------------------------------
		// GET: NhanViens/Create
		[Authorize(Roles = "root, giamdoc")]
		public ActionResult Create()
		{
			Statuscheck();
			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
			return View();
		}
		// POST: NhanViens/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "root, giamdoc")]
		public ActionResult Create([Bind(Include = "Employee_ID,Status,Ten,Email,SDT,NgayTao,NgaySua,DOB,MatKhau,Role_ID")] NhanVien nhanVien)
		{
			Statuscheck();
			if (ModelState.IsValid)
			{
				var email_dup_check = from edc in db.NhanViens select edc.Email;
				var phone_dup_check = from edc in db.NhanViens select edc.SDT;

				int check = 0;
				if (email_dup_check.Contains(nhanVien.Email))
				{
					ViewBag.err_email = "Email already taken";
					check++;
				}

				if (phone_dup_check.Contains(nhanVien.SDT))
				{
					ViewBag.err_SDT = "Phone number already taken";
					check++;
				}

				if (nhanVien.MatKhau.Length > 16)
				{
					ViewBag.err_l = "Character string limited to 16 characters";
					check++;
				}

				if (check > 0)
				{
					ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
					return View(nhanVien);
				}
				string passwordHash = BCrypt.Net.BCrypt.HashPassword(nhanVien.MatKhau);

				nhanVien.MatKhau = passwordHash;
				nhanVien.NgayTao = DateTime.Now;
				nhanVien.NgaySua = DateTime.Now;
				db.NhanViens.Add(nhanVien);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
			return View(nhanVien);
		}

		//EDIT------------------------------------------------------------------------------------------------
		// GET: NhanViens/Edit/5
		[Authorize(Roles = "root, giamdoc")]
		public ActionResult Edit(int? id)
		{
			Statuscheck();
			if (id == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}

			if (id == 1)
			{
				return RedirectToAction("Index");
			}

			NhanVien nhanVien = db.NhanViens.Find(id);
			if (nhanVien == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}
			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", nhanVien.Role_ID);
			return View(nhanVien);
		}

		// POST: NhanViens/Edit/5
		String SqlCon = ConfigurationManager.ConnectionStrings["ModelContext"].ConnectionString;
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "root, giamdoc")]
		public ActionResult Edit([Bind(Include = "Employee_ID,Status,Ten,Email,SDT,NgayTao,NgaySua,DOB,MatKhau,Role_ID")] NhanVien nhanVien)
		{
			Statuscheck();
			if (ModelState.IsValid)
			{
				var email_dup_check = from edc in db.NhanViens select edc.Email;
				var phone_dup_check = from edc in db.NhanViens select edc.SDT;

				int check = 0;
				var self_check = db.NhanViens.FirstOrDefault(n => n.Employee_ID == nhanVien.Employee_ID);

				if (email_dup_check.Contains(nhanVien.Email))
				{
					if (self_check.Email == nhanVien.Email) //phải check email trùng đó có phải là email của chính nhân viên được sửa ko
					{
						goto jump;
					}
					ViewBag.err_email = "Email already taken";
					check++;
				}

			jump: //nhảy vào đây

				if (phone_dup_check.Contains(nhanVien.SDT))
				{
					if (self_check.SDT == nhanVien.SDT) //tự hiểu
					{
						goto another_jump;
					}
					ViewBag.err_SDT = "Phone number already taken";
					check++;
				}
			another_jump: //nhảy tiếp

				if (nhanVien.MatKhau.Length > 16)
				{
					ViewBag.err_l = "Character string limited to 16 characters";
					check++;
				}
				if (check > 0)
				{
					ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
					return View(nhanVien);
				}


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
					Status = nhanVien.Status,
					DOB = nhanVien.DOB,
					Email = nhanVien.Email,
					SDT = nhanVien.SDT,
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

		//DELETE------------------------------------------------------------------------------------------------
		// GET: NhanViens/Delete/5
		[Authorize(Roles = "root, giamdoc")]
		public ActionResult Delete(int? id)
		{
			Statuscheck();
			if (id == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}

			int i = 0;
			i++;
			if (id == 1)
			{
				return RedirectToAction("Index");
			}

			NhanVien nhanVien = db.NhanViens.Find(id);
			if (nhanVien == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}
			return View(nhanVien);
		}

		// POST: NhanViens/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "root, giamdoc")]
		public ActionResult DeleteConfirmed(int id)
		{
			Statuscheck();
			NhanVien nhanVien = db.NhanViens.Find(id);
			db.NhanViens.Remove(nhanVien);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

