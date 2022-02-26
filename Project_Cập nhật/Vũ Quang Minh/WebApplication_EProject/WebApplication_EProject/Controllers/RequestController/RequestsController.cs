using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication_EProject.Models;
using WebApplication_EProject.Models.Request;

namespace WebApplication_EProject.Controllers.RequestController
{
	[Authorize]
	public class RequestsController : Controller
	{
		String ck;
		String notify_successful = "Cập nhật thành công";
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

		public void Logcheck(DateTime DateAdd, int role_check, int employ_check)
		{
			Statuscheck();
			//begin lịch sử hóa đơn
			var check_request = db.Requests.FirstOrDefault(r => r.DateAdd == DateAdd);

			Log logg = new Log();
			logg.Request_Id = check_request.Request_Id;
			logg.Role_ID = role_check;
			logg.Employee_ID = employ_check;
			logg.LogName = "Tạo Yêu cầu";
			logg.LogDate = DateTime.Now;
			db.Logs.Add(logg);
			db.SaveChanges();
			//end lịch sử hóa đơn
		}
		public void Logcheck_id(int id, String ck)
		{
			Statuscheck();
			//begin lịch sử hóa đơn
			var check_request = db.Requests.FirstOrDefault(r => r.Request_Id == id);
			var username = User.Identity.GetUserName();
			var user_check = db.NhanViens.FirstOrDefault(n => n.Email == username);

			Log logg = new Log();
			logg.Request_Id = check_request.Request_Id;
			logg.Role_ID = user_check.Role_ID;
			logg.Employee_ID = user_check.Employee_ID;
			logg.LogDate = DateTime.Now;
			if (ck == "Delete")
			{
				logg.LogName = "Hủy Yêu cầu";
			}
			else if (ck == "-1")
			{
				logg.LogName = "Từ chối đơn hàng";
			}
			else if (ck == "1")
			{
				logg.LogName = "Chấp thuận";
			}
			else if (ck == "2")
			{
				logg.LogName = "Giám đốc Chấp thuận";
			}
			else if (ck == "tạm hoãn")
			{
				logg.LogName = "tạm hoãn";
			}
			else if (ck == "Nhận Hàng")
			{
				logg.LogName = "Nhận Hàng";
			}
			else if (ck == "Trả Hàng")
			{
				logg.LogName = "Trả Hàng";
			}
			else if (ck == "Nhận Lại hàng")
			{
				logg.LogName = "Nhận Lại hàng";
			}
			else if (ck == "Ép tiền")
			{
				logg.LogName = "Ép tiền";
			}
			else if (ck == "Tạm hoãn check tiền")
			{
				logg.LogName = "Tạm hoãn check tiền";
			}
			else if (ck == "Check giá thành công")
			{
				logg.LogName = "Check giá thành công";
			}
			else if (ck == "Từ chối giá")
			{
				logg.LogName = "Từ chối giá";
			}
			else if (ck == "Gửi tiền")
			{
				logg.LogName = "Gửi tiền";
			}
			else if (ck == "Mua Hàng")
			{
				logg.LogName = "Mua Hàng";
			}
			else if (ck == "Nhân sự nhận Hàng")
			{
				logg.LogName = "Nhân sự nhận Hàng";
			}
			db.Logs.Add(logg);

			//end lịch sử hóa đơn
		}

		// GET: Requests
		public ActionResult Index(String Status_Check, String Role_ID)
		{
			Statuscheck();
			//begin cập nhật cho nguyên
			if (Status_Check == null || Role_ID == null)
			{
				goto Here;
			}
			if (Status_Check != "" && Role_ID != "")
			{
				int check_status = Convert.ToInt32(Status_Check);
				int check_role = Convert.ToInt32(Role_ID);
				var requestss = from r in db.Requests where r.Role_ID == check_role && r.Status == check_status select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(requestss);
			}

			if (Status_Check != "")
			{

				int check_status = Convert.ToInt32(Status_Check);
				var requestss = from r in db.Requests where r.Status == check_status select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(requestss);
			}
			else if (Role_ID != "")
			{
				int check_role = Convert.ToInt32(Role_ID);
				var requestss = from r in db.Requests where r.Role_ID == check_role select r;
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(requestss);
			}

		Here: //đi ra đây
			  //end cập nhật cho nguyên

			if (TempData["app_false"] != null)
			{
				ViewBag.app_false = TempData["app_false"];
			}
			if (TempData["Notify"] != null)
			{
				ViewBag.Notify = TempData["Notify"];
			}
			var requests = db.Requests.Include(r => r.NhanVien).Include(r => r.Role).Include(r => r.VanPhongPham);

			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
			return View(requests);
		}

		[Authorize(Roles = "root, giamdoc, phong_vattu, phong_nhansu, phong_ketoan")]
		public ActionResult Index_Group_Product(String Status_Check, String Role_ID)
		{
			Statuscheck();
			//begin cập nhật cho nguyên
			if (Status_Check == null || Role_ID == null)
			{
				goto Here;
			}
			if (Status_Check != "" && Role_ID != "")
			{
				int check_status = Convert.ToInt32(Status_Check);
				int check_role = Convert.ToInt32(Role_ID);
				var request_list_haha = from r in db.Requests
										where r.Status == check_status && r.Role_ID == check_role
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
										};
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(request_list_haha.ToList());
			}

			if (Status_Check != "")
			{

				int check_status = Convert.ToInt32(Status_Check);
				var request_list_haha = from r in db.Requests
										where r.Status == check_status
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
										};
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(request_list_haha.ToList());
			}
			else if (Role_ID != "")
			{
				int check_role = Convert.ToInt32(Role_ID);
				var request_list_haha = from r in db.Requests
										where r.Role_ID == check_role
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
										};
				ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
				return View(request_list_haha.ToList());
			}

		Here: //đi ra đây

			//end cập nhật cho nguyên

			//begin notify
			if (TempData["app_false"] != null)
			{
				ViewBag.app_false = TempData["app_false"];
			}
			if (TempData["no_zero"] != null)
			{
				ViewBag.no_zero = TempData["no_zero"];
			}
			if (TempData["Notify"] != null)
			{
				ViewBag.Notify = TempData["Notify"];
			}
			//end notify

			//display
			var request_list = from r in db.Requests
							   where r.Status == 2 || r.Status == 3 || r.Status == 4 || r.Status == 5 || r.Status == 6
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
							   };

			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
			return View(request_list.ToList());
		}

		// GET: Requests/Details/5
		public ActionResult Details(int? id)
		{
			Statuscheck();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Request request = db.Requests.Find(id);
			if (request == null)
			{
				return HttpNotFound();
			}
			return View(request);
		}

		// GET: Requests/Create
		public ActionResult Create()
		{
			Statuscheck();
			ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten");
			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName");
			ViewBag.productID = new SelectList(db.VanPhongPhams, "productID", "productName");
			return View();
		}

		// POST: Requests/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Request_Id,Employee_ID,Role_ID,productID,Unit,Quantity,Purpose,DateAdd,Status,Pause,Note")] Request request)
		{
			Statuscheck();
			if (ModelState.IsValid)
			{
				var check_username = User.Identity.GetUserName();

				var check_user = db.NhanViens.Where(c => c.Email == check_username);

				int role_check = (int)check_user.Select(r => r.Role_ID).First();
				int employ_check = (int)check_user.Select(r => r.Employee_ID).First();
				DateTime now = DateTime.Now;
				String Datenow = Convert.ToString(now);
				if (role_check == 2)
				{
					TempData["Notify"] = "Tạo thành công đơn hàng";
					request.Employee_ID = employ_check;
					request.Role_ID = role_check;
					request.DateAdd = Convert.ToDateTime(Datenow);
					request.Status = 1;
					request.Price = 0;
					request.Note = "";
					db.Requests.Add(request);
					db.SaveChanges();
					Logcheck(Convert.ToDateTime(Datenow), role_check, employ_check);

					return RedirectToAction("Index");
				}
				TempData["Notify"] = "Tạo thành công đơn hàng";
				request.Employee_ID = employ_check;
				request.Role_ID = role_check;
				request.DateAdd = Convert.ToDateTime(Datenow);
				request.Price = 0;
				request.Note = "";
				db.Requests.Add(request);
				db.SaveChanges();
				Logcheck(Convert.ToDateTime(Datenow), role_check, employ_check);
				return RedirectToAction("Index");
			}

			ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", request.Employee_ID);
			ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", request.Role_ID);
			ViewBag.productID = new SelectList(db.VanPhongPhams, "productID", "productName", request.productID);
			return View(request);
		}


		//Get: trưởng phòng check thông tin
		[Authorize(Roles = "truongphong_sanxuat, truongphong_nhansu_ketoan_vattu, root")]
		public ActionResult TruongPhong_Check(int? id)
		{
			Statuscheck();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Request request = db.Requests.Find(id);
			if (request == null)
			{
				return HttpNotFound();
			}
			var user_check = User.Identity.GetUserName();
			var user_role_check = db.NhanViens.FirstOrDefault(ur => ur.Email == user_check);
			int role_check = (int)request.Role_ID;
			if (user_role_check.Role_ID == 8)
			{

				if (role_check == 6 || role_check == 7 || role_check == 1)
				{
					TempData["app_false"] = "Không được phép check trưởng phòng sản xuất và nhân viên sản xuất";
					return RedirectToAction("Index");
				}
			}
			else if (user_role_check.Role_ID == 6)
			{
				if (role_check == 3 || role_check == 4 || role_check == 5 || role_check == 8)
				{
					TempData["app_false"] = "Không được phép check nhân sự, vật tư, kế toán và trưởng phòng của 3 ban đó";
					return RedirectToAction("Index");
				}
			}

			return View(request);
		}

		static String SqlCon = ConfigurationManager.ConnectionStrings["ModelContext"].ConnectionString;
		SqlConnection con = new SqlConnection(SqlCon);

		[Authorize(Roles = "truongphong_sanxuat, truongphong_nhansu_ketoan_vattu, root")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult TruongPhong_Check(int Request_Id, String Status, bool approve, String Note)
		{
			Statuscheck();
			string sqlQuery = "Update Requests SET Status = @Status, Pause = @Pause, Note = @Note where Request_Id = @Request_Id";

			if (Status == "0")
			{
				return RedirectToAction("Index");
			}
			if (approve == false)
			{
				TempData["app_false"] = "Chưa xác nhận yêu cầu";
				return RedirectToAction("Index");
			}
			//tạm hoãn
			ck = "tạm hoãn";
			if (Status == ck)
			{

				con.Open();
				SqlCommand cmd_tamhoan = new SqlCommand(sqlQuery, con);
				cmd_tamhoan.Parameters.AddWithValue("@Status", 0);
				cmd_tamhoan.Parameters.AddWithValue("@Pause", true);
				cmd_tamhoan.Parameters.AddWithValue("@Note", "");
				cmd_tamhoan.Parameters.AddWithValue("@Request_Id", Request_Id);
				int check_tamhoan = cmd_tamhoan.ExecuteNonQuery();
				con.Close();
				if (check_tamhoan == 1)
				{
					TempData["Notify"] = "Đã cập nhật thành công";
					Logcheck_id(Request_Id, ck);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}

			//từ chối
			if (Status == "-1")
			{
				if (Note == "")
				{
					TempData["app_false"] = "Chưa ghi rõ lý do từ chối";
					return RedirectToAction("Index");
				}
				con.Open();
				SqlCommand cmd_tuchoi = new SqlCommand(sqlQuery, con);
				cmd_tuchoi.Parameters.AddWithValue("@Status", Status);
				cmd_tuchoi.Parameters.AddWithValue("@Pause", false);
				cmd_tuchoi.Parameters.AddWithValue("@Note", Note);
				cmd_tuchoi.Parameters.AddWithValue("@Request_Id", Request_Id);
				int check_tuchoi = cmd_tuchoi.ExecuteNonQuery();
				con.Close();
				if (check_tuchoi == 1)
				{
					TempData["Notify"] = notify_successful;
					if (Status == "1")
					{
						Logcheck_id(Request_Id, "1");
						db.SaveChanges();
					}
					else if (Status == "-1")
					{
						Logcheck_id(Request_Id, "-1");
						db.SaveChanges();
					}
					return RedirectToAction("Index");
				}
			}
			// đồng ý
			con.Open();
			SqlCommand cmd = new SqlCommand(sqlQuery, con);
			cmd.Parameters.AddWithValue("@Status", Status);
			cmd.Parameters.AddWithValue("@Pause", false);
			cmd.Parameters.AddWithValue("@Note", "");
			cmd.Parameters.AddWithValue("@Request_Id", Request_Id);
			int check = cmd.ExecuteNonQuery();
			con.Close();
			if (check == 1)
			{
				TempData["Notify"] = notify_successful;
				if (Status == "1")
				{
					Logcheck_id(Request_Id, "1");
					db.SaveChanges();
				}
				else if (Status == "-1")
				{
					Logcheck_id(Request_Id, "-1");
					db.SaveChanges();
				}
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		//Get: giám đốc check thông tin nhân viên yêu cầu
		[Authorize(Roles = "giamdoc, root")]
		public ActionResult GiamDoc_Check_NhanSu(int? id)
		{
			Statuscheck();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Request request = db.Requests.Find(id);
			if (request == null)
			{
				return HttpNotFound();
			}
			return View(request);
		}

		[Authorize(Roles = "giamdoc, root")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult GiamDoc_Check_NhanSu(int Request_Id, String Status, bool approve, String Note)
		{
			Statuscheck();

			string sqlQuery = "Update Requests SET Status = @Status, Pause = @Pause, Note = @Note where Request_Id = @Request_Id";

			if (Status == "0")
			{
				return RedirectToAction("Index");
			}
			if (approve == false)
			{
				TempData["app_false"] = "Chưa xác nhận yêu cầu";
				return RedirectToAction("Index");
			}
			//tạm hoãn
			ck = "tạm hoãn";
			if (Status == ck)
			{

				con.Open();
				SqlCommand cmd_tamhoan = new SqlCommand(sqlQuery, con);
				cmd_tamhoan.Parameters.AddWithValue("@Status", 1);
				cmd_tamhoan.Parameters.AddWithValue("@Pause", true);
				cmd_tamhoan.Parameters.AddWithValue("@Note", "");
				cmd_tamhoan.Parameters.AddWithValue("@Request_Id", Request_Id);
				int check_tamhoan = cmd_tamhoan.ExecuteNonQuery();
				con.Close();
				if (check_tamhoan == 1)
				{
					TempData["Notify"] = "Đã cập nhật thành công";
					Logcheck_id(Request_Id, ck);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}

			//từ chối
			if (Status == "-1")
			{
				if (Note == "")
				{
					TempData["app_false"] = "Chưa ghi rõ lý do từ chối";
					return RedirectToAction("Index");
				}
				con.Open();
				SqlCommand cmd_tuchoi = new SqlCommand(sqlQuery, con);
				cmd_tuchoi.Parameters.AddWithValue("@Status", Status);
				cmd_tuchoi.Parameters.AddWithValue("@Pause", false);
				cmd_tuchoi.Parameters.AddWithValue("@Note", Note);
				cmd_tuchoi.Parameters.AddWithValue("@Request_Id", Request_Id);
				int check_tuchoi = cmd_tuchoi.ExecuteNonQuery();
				con.Close();
				if (check_tuchoi == 1)
				{
					TempData["Notify"] = notify_successful;
					if (Status == "1")
					{
						Logcheck_id(Request_Id, "1");
						db.SaveChanges();
					}
					else if (Status == "-1")
					{
						Logcheck_id(Request_Id, "-1");
						db.SaveChanges();
					}
					return RedirectToAction("Index");
				}
			}
			// đồng ý
			con.Open();
			SqlCommand cmd = new SqlCommand(sqlQuery, con);
			cmd.Parameters.AddWithValue("@Status", Status);
			cmd.Parameters.AddWithValue("@Pause", false);
			cmd.Parameters.AddWithValue("@Note", "");
			cmd.Parameters.AddWithValue("@Request_Id", Request_Id);
			int check = cmd.ExecuteNonQuery();
			con.Close();
			if (check == 1)
			{
				TempData["Notify"] = notify_successful;
				if (Status == "2")
				{
					Logcheck_id(Request_Id, "2");
					db.SaveChanges();
				}
				else if (Status == "-1")
				{
					Logcheck_id(Request_Id, "-1");
					db.SaveChanges();
				}
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		//begin group by 

		//vật tư ép giá
		[Authorize(Roles = "phong_vattu, root")]
		public ActionResult Input_Price(string role, string product, string unit, string quantity, string price, string status, string note)
		{
			Statuscheck();
			if (role == null || product == null || unit == null || quantity == null || price == null || status == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}
			ViewBag.role = role;
			ViewBag.product = product;
			ViewBag.unit = unit;
			ViewBag.quantity = quantity;
			ViewBag.price = price;
			ViewBag.status = status;
			ViewBag.note = note;

			int i = 0;
			i++;
			return View();
		}

		[Authorize(Roles = "phong_vattu, root")]
		[HttpPost]
		public ActionResult Input_Price(string RoleName, string productName, string Unit, string Quantity, string Price, string Status)
		{
			Statuscheck();
			if (Convert.ToInt64(Price) == 0)
			{
				TempData["no_zero"] = "Nhập số khác 0";
				return RedirectToAction("Index_Group_Product");
			}

			//thành công
			var rollid_check = db.Roles.FirstOrDefault(r => r.RoleName == RoleName);

			var productid_check = db.VanPhongPhams.FirstOrDefault(r => r.productName == productName);

			string sqlQuery = "Update Requests SET Price = @Price, Note = @Note, Status = @Status where Role_ID = @Role_ID and productID = @productID and Unit = @Unit and Status = @Status_first";

			int role_id = rollid_check.Role_ID;
			int product_id = productid_check.productID;

			con.Open();
			SqlCommand cmd_nhaphang = new SqlCommand(sqlQuery, con);

			//long total = Convert.ToInt64(Quantity) * Convert.ToInt64(Price);
			int status_update = Convert.ToInt32(Status) + 1;

			cmd_nhaphang.Parameters.AddWithValue("@Price", Price);
			cmd_nhaphang.Parameters.AddWithValue("@Status", status_update);
			cmd_nhaphang.Parameters.AddWithValue("@Role_ID", role_id);
			cmd_nhaphang.Parameters.AddWithValue("@Note", "");
			cmd_nhaphang.Parameters.AddWithValue("@productID", product_id);
			cmd_nhaphang.Parameters.AddWithValue("@Unit", Unit);
			cmd_nhaphang.Parameters.AddWithValue("@Status_first", Status);
			int check_nhaphang = cmd_nhaphang.ExecuteNonQuery();
			con.Close();

			if (check_nhaphang > 0)
			{
				TempData["Notify"] = "Ép giá thành công";
				long price = Convert.ToInt64(Price);
				int status = Convert.ToInt16(Status);

				var requestid_check = from r in db.Requests
									  where r.Role_ID == role_id && r.productID == role_id && r.Price == price && r.Status == status_update
									  select r.Request_Id;

				foreach (var item in requestid_check)
				{
					int id_request = Convert.ToInt16(item);
					Logcheck_id(id_request, "Ép tiền");
				}
				db.SaveChanges();
				return RedirectToAction("Index_Group_Product");
			}
			return RedirectToAction("Index_Group_Product");
		}

		//giám đốc duyệt giá

		[Authorize(Roles = "giamdoc, root")]
		public ActionResult Check_Price(string role, string product, string unit, string quantity, string price, string status, bool pause, string note)
		{
			Statuscheck();
			if (role == null || product == null || unit == null || quantity == null || price == null || status == null)
			{
				return RedirectToAction("Error_Nothing", "Home");
			}
			ViewBag.role = role;
			ViewBag.product = product;
			ViewBag.unit = unit;
			ViewBag.quantity = quantity;
			ViewBag.price = price;
			ViewBag.status = status;
			ViewBag.pause = pause;
			ViewBag.note = note;
			ViewBag.tontien = Convert.ToInt64(quantity) * Convert.ToInt64(price);
			return View();
		}

		[Authorize(Roles = "giamdoc, root")]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Check_Price(string RoleName, string productName, string Unit, string Status_First, string Status, bool approve, string Note)
		{
			Statuscheck();
			var rollid_check = db.Roles.FirstOrDefault(r => r.RoleName == RoleName);
			var productid_check = db.VanPhongPhams.FirstOrDefault(r => r.productName == productName);

			string sqlQuery = "Update Requests SET Status = @Status, Pause = @Pause, Note = @Note where Role_ID = @Role_ID and productID = @productID and Unit = @Unit and Status = @Status_first";

			if (Status == "3")
			{
				return RedirectToAction("Index_Group_Product");
			}
			if (approve == false)
			{
				TempData["app_false"] = "Chưa xác nhận yêu cầu";
				return RedirectToAction("Index_Group_Product");
			}
			if (Status == "0")
			{
				con.Open();
				SqlCommand cmd_checkhang = new SqlCommand(sqlQuery, con);
				cmd_checkhang.Parameters.AddWithValue("@Status", Status_First);
				cmd_checkhang.Parameters.AddWithValue("@Pause", true);
				cmd_checkhang.Parameters.AddWithValue("@Note", "");
				cmd_checkhang.Parameters.AddWithValue("@Role_ID", rollid_check.Role_ID);
				cmd_checkhang.Parameters.AddWithValue("@productID", productid_check.productID);
				cmd_checkhang.Parameters.AddWithValue("@Unit", Unit);
				cmd_checkhang.Parameters.AddWithValue("@Status_first", Status_First);
				int check_checkhang = cmd_checkhang.ExecuteNonQuery();
				con.Close();

				if (check_checkhang == 1)
				{
					TempData["Notify"] = notify_successful;
					int status = Convert.ToInt16(Status_First);
					int role_id = rollid_check.Role_ID;

					var requestid_check = from r in db.Requests
										  where r.Role_ID == role_id && r.productID == role_id && r.Status == status
										  select r.Request_Id;

					foreach (var item in requestid_check)
					{
						int id_request = Convert.ToInt16(item);
						Logcheck_id(id_request, "Tạm hoãn check tiền");
					}
					db.SaveChanges();
				}
				return RedirectToAction("Index_Group_Product");
			}

			//thành công, từ chối





			if (Status == "2")
			{
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", Status);
				cmd.Parameters.AddWithValue("@Pause", false);
				cmd.Parameters.AddWithValue("@Note", Note);
				cmd.Parameters.AddWithValue("@Role_ID", rollid_check.Role_ID);
				cmd.Parameters.AddWithValue("@productID", productid_check.productID);
				cmd.Parameters.AddWithValue("@Unit", Unit);
				cmd.Parameters.AddWithValue("@Status_first", Status_First);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				if (check == 1)
				{
					TempData["Notify"] = notify_successful;
					int status = Convert.ToInt16(Status);
					int role_id = rollid_check.Role_ID;
					var requestid_check = from r in db.Requests
										  where r.Role_ID == role_id && r.productID == role_id && r.Status == status
										  select r.Request_Id;

					foreach (var item in requestid_check)
					{
						int id_request = Convert.ToInt16(item);
						Logcheck_id(id_request, "Từ chối giá");
					}
					db.SaveChanges();
				}
				return RedirectToAction("Index_Group_Product");
			}

			else
			{
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", Status);
				cmd.Parameters.AddWithValue("@Pause", false);
				cmd.Parameters.AddWithValue("@Note", "");
				cmd.Parameters.AddWithValue("@Role_ID", rollid_check.Role_ID);
				cmd.Parameters.AddWithValue("@productID", productid_check.productID);
				cmd.Parameters.AddWithValue("@Unit", Unit);
				cmd.Parameters.AddWithValue("@Status_first", Status_First);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				if (check > 1)
				{
					TempData["Notify"] = notify_successful;
					int status = Convert.ToInt16(Status);
					int role_id = rollid_check.Role_ID;
					var requestid_check = from r in db.Requests
										  where r.Role_ID == role_id && r.productID == role_id && r.Status == status
										  select r.Request_Id;

					foreach (var item in requestid_check)
					{
						int id_request = Convert.ToInt16(item);
						Logcheck_id(id_request, "Check giá thành công");
					}
					db.SaveChanges();
				}



				return RedirectToAction("Index_Group_Product");
			}
		}


			//ke toan tra tien cho phòng vật tư

			[Authorize(Roles = "phong_ketoan, root")]
			public ActionResult Send_Money(string role, string product, string unit, string quantity, string price, string status, string note)
			{
			Statuscheck();
			if (role == null || product == null || unit == null || quantity == null || price == null || status == null)
				{
					return RedirectToAction("Error_Nothing", "Home");
				}
				ViewBag.role = role;
				ViewBag.product = product;
				ViewBag.unit = unit;
				ViewBag.quantity = quantity;
				ViewBag.price = price;
				ViewBag.status = status;
				ViewBag.note = note;
				ViewBag.tontien = Convert.ToInt64(quantity) * Convert.ToInt64(price);

				return View();
			}

			[Authorize(Roles = "phong_ketoan, root")]
			[ValidateAntiForgeryToken]
			[HttpPost]
			public ActionResult Send_Money(string RoleName, string productName, string Unit, string Status, bool approve)
			{
			Statuscheck();
			var rollid_check = db.Roles.FirstOrDefault(r => r.RoleName == RoleName);
				var productid_check = db.VanPhongPhams.FirstOrDefault(r => r.productName == productName);

				string sqlQuery = "Update Requests SET Status = @Status where Role_ID = @Role_ID and productID = @productID and Unit = @Unit and Status = @Status_first";

				if (approve == false)
				{
					TempData["app_false"] = "Chưa xác nhận yêu cầu";
					return RedirectToAction("Index_Group_Product");
				}

				int new_Status = Convert.ToInt16(Status) + 1;
				// từ chối
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", new_Status);
				cmd.Parameters.AddWithValue("@Note", "");
				cmd.Parameters.AddWithValue("@Role_ID", rollid_check.Role_ID);
				cmd.Parameters.AddWithValue("@productID", productid_check.productID);
				cmd.Parameters.AddWithValue("@Unit", Unit);
				cmd.Parameters.AddWithValue("@Status_first", Status);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				if (check > 1)
				{
					TempData["Notify"] = notify_successful;
					int status = Convert.ToInt16(new_Status);
					int role_id = rollid_check.Role_ID;

					var requestid_check = from r in db.Requests
										  where r.Role_ID == role_id && r.productID == role_id && r.Status == new_Status
										  select r.Request_Id;

					foreach (var item in requestid_check)
					{
						int id_request = Convert.ToInt16(item);
						Logcheck_id(id_request, "Gửi tiền");
					}
					db.SaveChanges();
					return RedirectToAction("Index_Group_Product");
				}
				return RedirectToAction("Index_Group_Product");
			}

			//vật tư đi mua hàng

			[Authorize(Roles = "phong_vattu, root")]
			public ActionResult Buy_Product(string role, string product, string unit, string quantity, string price, string status, string note)
			{
			Statuscheck();
			if (role == null || product == null || unit == null || quantity == null || price == null || status == null)
				{
					return RedirectToAction("Error_Nothing", "Home");
				}
				ViewBag.role = role;
				ViewBag.product = product;
				ViewBag.unit = unit;
				ViewBag.quantity = quantity;
				ViewBag.price = price;
				ViewBag.status = status;
				ViewBag.note = note;
				ViewBag.tontien = Convert.ToInt64(quantity) * Convert.ToInt64(price);

				int i = 0;
				i++;
				return View();
			}

			[Authorize(Roles = "phong_vattu, root")]
			[ValidateAntiForgeryToken]
			[HttpPost]
			public ActionResult Buy_Product(string RoleName, string productName, string Unit, string Status, bool approve)
			{
			Statuscheck();

			var rollid_check = db.Roles.FirstOrDefault(r => r.RoleName == RoleName);
				var productid_check = db.VanPhongPhams.FirstOrDefault(r => r.productName == productName);

				string sqlQuery = "Update Requests SET Status = @Status where Role_ID = @Role_ID and productID = @productID and Unit = @Unit and Status = @Status_first";

				if (approve == false)
				{
					TempData["app_false"] = "Chưa xác nhận yêu cầu";
					return RedirectToAction("Index_Group_Product");
				}

				int new_Status = Convert.ToInt16(Status) + 1;
				// từ chối
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", new_Status);
				cmd.Parameters.AddWithValue("@Note", "");
				cmd.Parameters.AddWithValue("@Role_ID", rollid_check.Role_ID);
				cmd.Parameters.AddWithValue("@productID", productid_check.productID);
				cmd.Parameters.AddWithValue("@Unit", Unit);
				cmd.Parameters.AddWithValue("@Status_first", Status);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				if (check > 1)
				{
					TempData["Notify"] = notify_successful;
					int status = Convert.ToInt16(new_Status);
					int role_id = rollid_check.Role_ID;

					var requestid_check = from r in db.Requests
										  where r.Role_ID == role_id && r.productID == role_id && r.Status == new_Status
										  select r.Request_Id;

					foreach (var item in requestid_check)
					{
						int id_request = Convert.ToInt16(item);
						Logcheck_id(id_request, "Mua Hàng");
					}
					db.SaveChanges();
					return RedirectToAction("Index_Group_Product");
				}
				return RedirectToAction("Index_Group_Product");
			}


			//phòng nhân sự nhân hàng

			[Authorize(Roles = "phong_nhansu, root")]
			public ActionResult Get_Product(string role, string product, string unit, string quantity, string status, string note)
			{
			Statuscheck();
			if (role == null || product == null || unit == null || quantity == null || status == null)
				{
					return RedirectToAction("Error_Nothing", "Home");
				}
				ViewBag.role = role;
				ViewBag.product = product;
				ViewBag.unit = unit;
				ViewBag.quantity = quantity;
				ViewBag.status = status;
				ViewBag.note = note;

				int i = 0;
				i++;
				return View();
			}

			[Authorize(Roles = "phong_nhansu, root")]
			[ValidateAntiForgeryToken]
			[HttpPost]
			public ActionResult Get_Product(string RoleName, string productName, string Unit, string Status, bool approve)
			{
			Statuscheck();
			var rollid_check = db.Roles.FirstOrDefault(r => r.RoleName == RoleName);
				var productid_check = db.VanPhongPhams.FirstOrDefault(r => r.productName == productName);

				string sqlQuery = "Update Requests SET Status = @Status where Role_ID = @Role_ID and productID = @productID and Unit = @Unit and Status = @Status_first";

				if (approve == false)
				{
					TempData["app_false"] = "Chưa xác nhận yêu cầu";
					return RedirectToAction("Index_Group_Product");
				}

				int new_Status = Convert.ToInt16(Status) + 1;
				// từ chối
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", new_Status);
				cmd.Parameters.AddWithValue("@Note", "");
				cmd.Parameters.AddWithValue("@Role_ID", rollid_check.Role_ID);
				cmd.Parameters.AddWithValue("@productID", productid_check.productID);
				cmd.Parameters.AddWithValue("@Unit", Unit);
				cmd.Parameters.AddWithValue("@Status_first", Status);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				if (check > 1)
				{
					TempData["Notify"] = notify_successful;
					int status = Convert.ToInt16(new_Status);
					int role_id = rollid_check.Role_ID;

					var requestid_check = from r in db.Requests
										  where r.Role_ID == role_id && r.productID == role_id && r.Status == new_Status
										  select r.Request_Id;

					foreach (var item in requestid_check)
					{
						int id_request = Convert.ToInt16(item);
						Logcheck_id(id_request, "Nhân sự nhận Hàng");
					}
					db.SaveChanges();
					return RedirectToAction("Index_Group_Product");
				}
				return RedirectToAction("Index_Group_Product");
			}

			//end group by 

			//thành viên từ các phòng ban nhân hàng
			public ActionResult Nhan_Hang(int? id, int employee_id)
			{
			Statuscheck();
			var check_username = User.Identity.GetUserName();
				var check_user = db.NhanViens.Where(c => c.Email == check_username);
				int employee_check = (int)check_user.Select(r => r.Employee_ID).First();
				if (employee_id != employee_check)
				{
					TempData["app_false"] = "Sai thành viên nhận hàng";
					return RedirectToAction("Index");
				}
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Request request = db.Requests.Find(id);
				if (request == null)
				{
					return HttpNotFound();
				}
				return View(request);
			}

			[ValidateAntiForgeryToken]
			[HttpPost]
			public ActionResult Nhan_Hang(int Request_Id, string Status, bool approve)
			{
			Statuscheck(); 
			string sqlQuery = "Update Requests SET Status = @Status, Note = @Note where Request_Id = @Request_Id";

				if (approve == false)
				{
					TempData["app_false"] = "Chưa xác nhận yêu cầu";
					return RedirectToAction("Index");
				}

				// đồng ý, từ chối
				int status_update = Convert.ToInt32(Status) + 1;
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", status_update);
				cmd.Parameters.AddWithValue("@Note", "");
				cmd.Parameters.AddWithValue("@Request_Id", Request_Id);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				int i = 0;
				i++;
				if (check == 1)
				{
					TempData["Notify"] = "Nhận Hàng thành công";
					Logcheck_id(Request_Id, "Nhận Hàng");
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}


			//thành viên trong các phòng ban trả hàng
			public ActionResult Tra_Hang(int? id, int employee_id)
			{
			Statuscheck();
			var check_username = User.Identity.GetUserName();
				var check_user = db.NhanViens.Where(c => c.Email == check_username);
				int employee_check = (int)check_user.Select(r => r.Employee_ID).First();
				if (employee_id != employee_check)
				{
					TempData["app_false"] = "Sai thành viên nhận hàng";
					return RedirectToAction("Index");
				}
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Request request = db.Requests.Find(id);
				if (request == null)
				{
					return HttpNotFound();
				}
				return View(request);
			}

			[ValidateAntiForgeryToken]
			[HttpPost]
			public ActionResult Tra_Hang(int Request_Id, string Status, bool approve)
			{
			Statuscheck();
			string sqlQuery = "Update Requests SET Status = @Status, Note = @Note where Request_Id = @Request_Id";

				if (approve == false)
				{
					TempData["app_false"] = "Chưa xác nhận yêu cầu";
					return RedirectToAction("Index");
				}

				// đồng ý, từ chối
				int status_update = Convert.ToInt32(Status) + 1;
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", status_update);
				cmd.Parameters.AddWithValue("@Note", "");
				cmd.Parameters.AddWithValue("@Request_Id", Request_Id);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				if (check == 1)
				{
					TempData["Notify"] = "Trả hàng thành công, đang chờ phòng nhân sự lấy hàng";
					Logcheck_id(Request_Id, "Trả Hàng");
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}

			//phòng nhân sự nhận lại hàng

			[Authorize(Roles = "phong_nhansu, root")]
			public ActionResult Nhan_lai_Hang(int? id)
			{
			Statuscheck();
			if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Request request = db.Requests.Find(id);
				if (request == null)
				{
					return HttpNotFound();
				}
				return View(request);
			}

			[Authorize(Roles = "phong_nhansu, root")]
			[ValidateAntiForgeryToken]
			[HttpPost]
			public ActionResult Nhan_lai_Hang(int Request_Id, string Status, bool approve)
			{
			Statuscheck();
			string sqlQuery = "Update Requests SET Status = @Status, Note = @Note where Request_Id = @Request_Id";

				if (approve == false)
				{
					TempData["app_false"] = "Chưa xác nhận yêu cầu";
					return RedirectToAction("Index");
				}

				// đồng ý, từ chối
				int status_update = Convert.ToInt32(Status) + 1;
				con.Open();
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				cmd.Parameters.AddWithValue("@Status", status_update);
				cmd.Parameters.AddWithValue("@Note", "");
				cmd.Parameters.AddWithValue("@Request_Id", Request_Id);
				int check = cmd.ExecuteNonQuery();
				con.Close();
				if (check == 1)
				{
					TempData["Notify"] = "Nhận Lại Hàng thành công";
					Logcheck_id(Request_Id, "Nhận Lại hàng");
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}

			//// GET: Requests/Edit/5
			//public ActionResult Edit(int? id)
			//{
			//	if (id == null)
			//	{
			//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//	}
			//	Request request = db.Requests.Find(id);
			//	if (request == null)
			//	{
			//		return HttpNotFound();
			//	}
			//	ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", request.Employee_ID);
			//	ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", request.Role_ID);
			//	ViewBag.productID = new SelectList(db.VanPhongPhams, "productID", "productName", request.productID);
			//	return View(request);
			//}

			//// POST: Requests/Edit/5
			//// To protect from overposting attacks, enable the specific properties you want to bind to, for 
			//// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
			//[HttpPost]
			//[ValidateAntiForgeryToken]
			//public ActionResult Edit([Bind(Include = "Request_Id,Employee_ID,Role_ID,productID,Unit,Quantity,Price,Purpose,DateAdd,Status,Note")] Request request)
			//{
			//	if (ModelState.IsValid)
			//	{
			//		db.Entry(request).State = EntityState.Modified;
			//		db.SaveChanges();
			//		return RedirectToAction("Index");
			//	}
			//	ViewBag.Employee_ID = new SelectList(db.NhanViens, "Employee_ID", "Ten", request.Employee_ID);
			//	ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "RoleName", request.Role_ID);
			//	ViewBag.productID = new SelectList(db.VanPhongPhams, "productID", "productName", request.productID);
			//	return View(request);
			//}

			// GET: Requests/Delete/5

			public ActionResult Delete(int? id)
			{
			Statuscheck();
			if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Request request = db.Requests.Find(id);
				if (request == null)
				{
					return HttpNotFound();
				}
				return View(request);
			}


			// POST: Requests/Delete/5
			[HttpPost, ActionName("Delete")]
			[ValidateAntiForgeryToken]
			public ActionResult DeleteConfirmed(int id)
			{
			Statuscheck();
			ck = "Delete";
				Request request = db.Requests.Find(id);
				request.Status = -2;
				db.Entry(request).State = EntityState.Modified;
				//db.Requests.Remove(request);
				db.SaveChanges();
				Logcheck_id(id, ck);
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
