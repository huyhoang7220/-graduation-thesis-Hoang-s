using Facebook;
using ManageRoles.Algorithm;
using ManageRoles.Filters;
using ManageRoles.Repository;
using ManageRoles.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ManageRoles.Controllers
{
    public class HomeController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        private readonly ILoaiTaiKhoan _loaiTaiKhoanService;
        private readonly ITaiKhoan _taiKhoanService;
        private readonly ISanPham _sanPhamService;
        private readonly IDonHang _donHangService;
        private readonly IChiTietDonHang _chiTietDHService;
        private readonly INhaSanXuat _nhaSXService;
        private readonly ITinhTrangDonHang _tinhTrangService;
        private readonly IDanhMuc _danhMucService;
        private readonly ISlide _slideService;
        public HomeController(ILoaiTaiKhoan loaiTaiKhoanService, ITaiKhoan taiKhoanService,
            ISanPham sanPhamService, IDonHang donHangService, IChiTietDonHang chiTietDHService,
            INhaSanXuat nhaSXService, ITinhTrangDonHang tinhTrangService, IDanhMuc danhMucService, ISlide slideService)
        {
            _loaiTaiKhoanService = loaiTaiKhoanService;
            _taiKhoanService = taiKhoanService;
            _sanPhamService = sanPhamService;
            _donHangService = donHangService;
            _chiTietDHService = chiTietDHService;
            _nhaSXService = nhaSXService;
            _tinhTrangService = tinhTrangService;
            _danhMucService = danhMucService;
            _slideService = slideService;
        }
        public ActionResult Index(string search)
        {
            if(!string.IsNullOrEmpty(search))
            {
                ViewBag.ListProduct = _sanPhamService.GetAll().Where(x => x.Actived && x.Ten.ToLower().Contains(search.ToLower()));
            }else
            {
                ViewBag.ListProduct = _sanPhamService.GetAll().Where(x => x.Actived);
            }
            ReloadCart();
            ViewBag.DanhMuc = _danhMucService.GetAll();
            ViewBag.ListLQ = _sanPhamService.GetAll().Take(5);
            //var result = GetAllCart();
            //ViewBag.ListCart = result;
            //ViewBag.Total = GetTotal();
            return View("Index");
        }

        public ActionResult Intro()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            return View("Intro");
        }

        public ActionResult Product(string Category,string type, string minPrice, string maxPrice)
        {
            ViewBag.Tittle = "Sản phẩm";
            var listProduct = new List<SanPhamModel>();
            ViewBag.DanhMuc = _danhMucService.GetAll();
            if (!string.IsNullOrEmpty(Category))
            {
                ViewBag.Tittle = _danhMucService.GetById(Int32.Parse(Category)).Ten;
                listProduct = _sanPhamService.GetAll().Where(x => x.Actived && x.IdDanhMuc == Int32.Parse(Category)).ToList();
                if (!string.IsNullOrEmpty(type))
                {
                    switch (type)
                    {
                        case "1":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived && x.IdDanhMuc == Int32.Parse(Category)).OrderBy(x => x.Ten).ToList();
                            break;
                        case "2":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived && x.IdDanhMuc == Int32.Parse(Category)).OrderByDescending(x => x.Ten).ToList();
                            break;
                        case "3":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived && x.IdDanhMuc == Int32.Parse(Category)).OrderByDescending(x => x.NgayNhap).ToList();
                            break;
                        case "4":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived && x.IdDanhMuc == Int32.Parse(Category)).OrderBy(x => x.Gia).ToList();
                            break;
                        case "5":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived && x.IdDanhMuc == Int32.Parse(Category)).OrderByDescending(x => x.Gia).ToList();
                            break;
                    }

                    if (!string.IsNullOrEmpty(minPrice))
                    {
                        if (string.IsNullOrEmpty(maxPrice))
                        {
                            listProduct = listProduct.Where(x => x.Gia > 1000000).ToList();
                        }
                        else
                        {
                            listProduct = listProduct.Where(x => x.Gia < Double.Parse(maxPrice) && x.Gia > Double.Parse(minPrice)).ToList();
                        }
                    }

                }else
                {
                    if (!string.IsNullOrEmpty(minPrice))
                    {
                        if (string.IsNullOrEmpty(maxPrice))
                        {
                            listProduct = listProduct.Where(x => x.Gia > 1000000).ToList();
                        }
                        else
                        {
                            listProduct = listProduct.Where(x => x.Gia < Double.Parse(maxPrice) && x.Gia > Double.Parse(minPrice)).ToList();
                        }
                    }
                }
                
            }
            else
            {
                listProduct = _sanPhamService.GetAll().Where(x => x.Actived).ToList();
                if (!string.IsNullOrEmpty(type))
                {
                    switch (type)
                    {
                        case "1":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived).OrderBy(x => x.Ten).ToList();
                            break;
                        case "2":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived).OrderByDescending(x => x.Ten).ToList();
                            break;
                        case "3":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived).OrderByDescending(x => x.NgayNhap).ToList();
                            break;
                        case "4":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived).OrderBy(x => x.Gia).ToList();
                            break;
                        case "5":
                            listProduct = _sanPhamService.GetAll().Where(x => x.Actived).OrderByDescending(x => x.Gia).ToList();
                            break;
                    }

                    if (!string.IsNullOrEmpty(minPrice))
                    {
                        if (string.IsNullOrEmpty(maxPrice))
                        {
                            listProduct = listProduct.Where(x => x.Gia > 1000000).ToList();
                        }
                        else
                        {
                            listProduct = listProduct.Where(x => x.Gia < Double.Parse(maxPrice) && x.Gia > Double.Parse(minPrice)).ToList();
                        }
                    }
                   
                }else
                {
                    if (!string.IsNullOrEmpty(minPrice))
                    {
                        if (string.IsNullOrEmpty(maxPrice))
                        {
                            listProduct = listProduct.Where(x => x.Gia > 1000000).ToList();
                        }
                        else
                        {
                            listProduct = listProduct.Where(x => x.Gia < Double.Parse(maxPrice) && x.Gia > Double.Parse(minPrice)).ToList();
                        }
                    }
                }
            }
            ViewBag.ListProduct = listProduct;
            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            string UserId = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];

            if (Request.Cookies["listCart"] != null && reqCookies != null)
            {
                UserId = reqCookies["UserID"].ToString();
                int UserCurentId = Convert.ToInt32(UserId);

                var list = GetAllCart(UserCurentId);
                ViewBag.ListProduct = list;
                ViewBag.Total = GetTotal(UserCurentId).ToString();
            }
            return View("Cart");
        }

        public ActionResult Shop()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            string UserId = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];

            if (Request.Cookies["listCart"] != null && reqCookies != null)
            {
                UserId = reqCookies["UserID"].ToString();
                int UserCurentId = Convert.ToInt32(UserId);

                var list = GetAllCartOrdered(UserCurentId);
                ViewBag.ListProduct = list;
            }
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            ViewBag.Slides = _slideService.GetAll().Where(x => x.IdSP == id);
            var model = _sanPhamService.GetById(id);
            ViewBag.NhaSX = _nhaSXService.GetById(model.IdNhaSanXuat).Ten;
            return View(model);
        }

        public ActionResult BuyProduct(int id, int? idDH)
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            string UserId = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            ViewBag.SoLuong = 1;
            ViewBag.IdDH = -1;
            if (reqCookies != null)
            {
                UserId = reqCookies["UserID"].ToString();
                int UserCurentId = Convert.ToInt32(UserId);
                ViewBag.TaiKhoan = _taiKhoanService.GetById(UserCurentId);

                var model = _sanPhamService.GetById(id);
                ViewBag.NhaSX = _nhaSXService.GetById(model.IdNhaSanXuat).Ten;


                if(idDH != null)
                {
                    var dh = _donHangService.GetById(idDH.Value);
                    var chiTietDH = _chiTietDHService.GetByIdDH(dh.Id);
                    ViewBag.SoLuong = chiTietDH.SoLuong;
                    ViewBag.IdDH = idDH;
                }
                return View(model);
            }
            else
            {
                return View("Index");
            }
           
        }

        public ActionResult ListStore()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            return View("ListStore");
        }

        public ActionResult Question()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            return View();
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var FbAppId = ConfigurationManager.AppSettings["FbAppId"];
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = FbAppId,
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",

            }
            );
            return Redirect(loginUrl.AbsoluteUri);
        }

        [HttpPost]
        public ActionResult Login(TaiKhoanModel model)
        {
            try
            {
                ViewBag.DanhMuc = _danhMucService.GetAll();
                if (!_taiKhoanService.CheckEmailExists(model.Email)) {
                    ViewBag.Message = ViewBag.Message = new ResultMessage()
                    {
                        Success = false,
                        Msg = "Email không tồn tại."
                    };

                    return View();
                };

                AesAlgorithm aesAlgorithm = new AesAlgorithm();

                var user = _taiKhoanService.GetByEmail(model.Email);
                var storedpassword = aesAlgorithm.DecryptString(user.MatKhau);

                if(storedpassword == model.MatKhau)
                {
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["UserID"] = user.Id.ToString();
                    userInfo["UserName"] = user.HoTen + user.Ten;
                    var loaiTK = _loaiTaiKhoanService.GetById(user.IdLoaiTK);
                    userInfo["Role"] = loaiTK.Ma;

                    userInfo.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userInfo);

                    ViewBag.Message = ViewBag.Message = new ResultMessage()
                    {
                        Success = true,
                        Msg = "Đã đăng nhập !"
                    };

                    var list = GetAllCart(user.Id);
                    HttpCookie totalCart = new HttpCookie("total");
                        totalCart.Value = GetTotal(user.Id).ToString();

                    HttpCookie listCart = new HttpCookie("listCart");
                        listCart.Value = JsonConvert.SerializeObject(list);

                    HttpCookie countCart = new HttpCookie("countCart");
                        countCart.Value = CountCart(user.Id).ToString();

                    totalCart.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(totalCart);

                    listCart.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(listCart);

                    countCart.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(countCart);

                    if (loaiTK.Ma.Trim() == "admin")
                    {
                        return RedirectToAction("Index", "HomeAdmin");
                    }else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                } else
                {
                    ViewBag.Message = ViewBag.Message = new ResultMessage()
                    {
                        Success = false,
                        Msg = "Sai mật khẩu."
                    };

                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ViewBag.Message = new ResultMessage()
                {
                    Success = false,
                    Msg = ex.ToString()
                };
            }
            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult SignUp(TaiKhoanModel model)
        {
            try
            {
                ViewBag.DanhMuc = _danhMucService.GetAll();
                var loaiTK = _loaiTaiKhoanService.GetByMa("khachhang");
                model.IdLoaiTK = loaiTK == null ? 2 : loaiTK.Id;

                if(_taiKhoanService.CheckEmailExists(model.Email)) {
                    ViewBag.Message = new ResultMessage() {
                        Success = false,
                        Msg = "Email đã tồn tại"
                    };
                    return View();
                }

                AesAlgorithm aesAlgorithm = new AesAlgorithm();
                model.MatKhau = aesAlgorithm.EncryptString(model.MatKhau);


                _taiKhoanService.Add(model);
                ViewBag.Message = ViewBag.Message = new ResultMessage()
                {
                    Success = true,
                    Msg = "Đăng ký thành công !"
                };
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Message = ViewBag.Message = new ResultMessage()
                {
                    Success = false,
                    Msg = ex.ToString()
                };
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {

            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();

                HttpCookie Cookies = new HttpCookie("WebTime");
                Cookies.Value = "";
                Cookies.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(Cookies);

                if (Request.Cookies["userInfo"] != null)
                {
                    var c = new HttpCookie("userInfo")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };

                    var d = new HttpCookie("total")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };

                    var e = new HttpCookie("listCart")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };

                    var g = new HttpCookie("countCart")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
                    Response.Cookies.Add(c);
                    Response.Cookies.Add(d);
                    Response.Cookies.Add(e);
                    Response.Cookies.Add(g);
                }

                // Response.Cookies.Remove("userInfo");
                //HttpContext.Session.Clear();
                //Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult About()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.DanhMuc = _danhMucService.GetAll();
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soLuong"></param>
        /// <param name="idSP"></param>
        /// <param name="type">
        /// type: 0 mua ngay tu dat hang
        /// type: 1 mua tu gio hang
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult OrderCart(int soLuong, int idSP, int type, 
            int idDH, string diachiGiao)
        {
            try
            {
                string UserId = string.Empty;
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    UserId = reqCookies["UserID"].ToString();
                    int UserCurentId = Convert.ToInt32(UserId);

                    var sanPham = _sanPhamService.GetById(idSP);

                    if (sanPham == null)
                    {
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                    }
                    // 0 dat ngay o trang chu
                    if(type == 0)
                    {
                        var _idDH = _donHangService.Add(new DonHangModel()
                        {
                            NgayTao = DateTime.Now,
                            IdTaiKhoan = UserCurentId,
                            ThanhTien = sanPham.Gia * soLuong,
                            IdTinhTrangDonHang = 1, // 1 là mơi đặt
                            IdSanPham = idSP,
                            DiaChiGiao = diachiGiao
                        });

                        _chiTietDHService.Add(new ChiTietDonHangModel()
                        {
                            GiaBan = sanPham.Gia,
                            SoLuong = soLuong,
                            IdDonHang = _idDH,
                            IdSanPham = idSP
                        });
                    }else
                    {
                        var dh = _donHangService.GetById(idDH);
                        dh.IdTinhTrangDonHang = 1;
                        _donHangService.Update(dh);

                        ReloadCart();
                    }
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddToCart(int idSP)
        {
            try
            {
                string UserId = string.Empty;
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    UserId = reqCookies["UserID"].ToString();
                    int UserCurentId = Convert.ToInt32(UserId);

                    var donHang = _donHangService.GetDHByUser(UserCurentId, idSP);
                    var sanPham = _sanPhamService.GetById(idSP);

                    if(sanPham == null)
                    {
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                    }

                    if(donHang != null)
                    {
                        
                        var chiTiet = _chiTietDHService.GetByIdDH(donHang.Id);
                        donHang.ThanhTien = (chiTiet.SoLuong + 1) * chiTiet.GiaBan;
                        chiTiet.SoLuong++;

                        var idChiTiet =_chiTietDHService.Update(chiTiet);
                        var idDH = _donHangService.Update(donHang);
                    }
                    else
                    {
                        var idDH = _donHangService.Add(new DonHangModel()
                        {
                            NgayTao = DateTime.Now,
                            IdTaiKhoan = UserCurentId,
                            ThanhTien = sanPham.Gia,
                            IdTinhTrangDonHang = 5,
                            IdSanPham = idSP
                        });

                        _chiTietDHService.Add(new ChiTietDonHangModel() {
                            GiaBan = sanPham.Gia,
                            SoLuong = 1,
                            IdDonHang = idDH,
                            IdSanPham = idSP
                        });
                    }
                }else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true },JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReloadCart()
        {
            try
            {
                string UserId = string.Empty;
                HttpCookie reqCookies = Request.Cookies["userInfo"];

                if (Request.Cookies["listCart"] != null && reqCookies != null)
                {
                    UserId = reqCookies["UserID"].ToString();
                    int UserCurentId = Convert.ToInt32(UserId); 

                    var c = new HttpCookie("listCart")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };

                    var d = new HttpCookie("total")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };

                    var e = new HttpCookie("countCart")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };

                    Response.Cookies.Add(c);
                    Response.Cookies.Add(d);
                    Response.Cookies.Add(e);

                    var list = GetAllCart(UserCurentId);
                    HttpCookie totalCart = new HttpCookie("total");
                        totalCart.Value = GetTotal(UserCurentId).ToString();

                    HttpCookie listCart = new HttpCookie("listCart");
                        listCart.Value = JsonConvert.SerializeObject(list);

                    HttpCookie countCart = new HttpCookie("countCart");
                        countCart.Value = CountCart(UserCurentId).ToString();

                    totalCart.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(totalCart);

                    listCart.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(listCart);

                    countCart.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(countCart);
                }

            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveCart(int idDH)
        {
            try
            {
                _donHangService.Delete(idDH);
                var chiTietDh = _chiTietDHService.GetByIdDH(idDH);
                _chiTietDHService.Delete(chiTietDh.Id);
                ReloadCart();

            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        private SanPhamModel GetSanPham(int id)
        {
            return _sanPhamService.GetById(id);
        }

        private ChiTietDonHangModel GetChiTietDH(int idDH)
        {
            return _chiTietDHService.GetByIdDH(idDH);
        }
 
        private List<DonHang> GetAllCart(int idUser)
        {
            var result = new List<DonHang>();

            var list = _donHangService.GetAll()
                .Where(
                    d => d.IdTaiKhoan == idUser && d.IdTinhTrangDonHang == 5
                );
                

            if (list.Count() > 0)
            {
                result.AddRange(list.Select(d => new DonHang()
                {
                    Id = d.Id,
                    TenSanPham = GetSanPham(d.IdSanPham).Ten,
                    AnhDaiDien = GetSanPham(d.IdSanPham).AnhDaiDien,
                    GiaBan = GetSanPham(d.IdSanPham).Gia.ToString(),
                    SoLuong = GetChiTietDH(d.Id).SoLuong.ToString(),
                    IdSP = d.IdSanPham
                }));
            }
            else
            {
                return result;
            }

            return result;
        }

        private List<DonHang> GetAllCartOrdered(int idUser)
        {
            var result = new List<DonHang>();

            var list = _donHangService.GetAll()
                .Where(
                    d => d.IdTaiKhoan == idUser && d.IdTinhTrangDonHang != 5
                );


            if (list.Count() > 0)
            {
                result.AddRange(list.Select(d => new DonHang()
                {
                    Id = d.Id,
                    TenSanPham = GetSanPham(d.IdSanPham).Ten,
                    AnhDaiDien = GetSanPham(d.IdSanPham).AnhDaiDien,
                    GiaBan = GetSanPham(d.IdSanPham).Gia.ToString(),
                    SoLuong = GetChiTietDH(d.Id).SoLuong.ToString(),
                    IdSP = d.IdSanPham,
                    TinhTrangDonHang = GetNameTinhTrangDH(d.IdTinhTrangDonHang)
                }));
            }
            else
            {
                return result;
            }

            return result;
        }

        private string GetNameTinhTrangDH(int idTT)
        {
            var tinhTrang = _tinhTrangService.GetById(idTT);
            return tinhTrang.TenTinhTrang;
        }
        private int CountCart(int idUser)
        {
            var list = _donHangService.GetAll()
                .Where(
                    d => d.IdTaiKhoan == idUser && d.IdTinhTrangDonHang == 5
                );
            return list.Count();
        }

        private double GetTotal(int idUser)
        {
            var result = 0.0;

            var list = _donHangService.GetAll()
                .Where(
                    d => d.IdTaiKhoan == idUser && d.IdTinhTrangDonHang == 5
                );


            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    result += item.ThanhTien;
                }
            }

            else
            {
                return result;
            }

            return result;
        }
    }
}