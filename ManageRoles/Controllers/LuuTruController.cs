using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageRoles.Algorithm;
using ManageRoles.Filters;
using ManageRoles.Models;
using ManageRoles.Repository;
using ManageRoles.ViewModels;
using System.Collections;
using Newtonsoft.Json;

namespace ManageRoles.Controllers
{
    public class LuuTruController : Controller
    {
        private readonly ILuuTruMaster _iLuuTruMaster;

        public LuuTruController(ILuuTruMaster iLuuTruMaster)
        {
            _iLuuTruMaster = iLuuTruMaster;
        }

        // GET: FollowYTController
        public ActionResult Index()
        {
            ViewBag.Data = _iLuuTruMaster.GetAll().Where(x => x.Actived );
            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Data = _iLuuTruMaster.GetAll();
            return View();
        }
        public ActionResult Edit(int id)
        {
            var model = _iLuuTruMaster.GetById(id);

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public JsonResult Edit(string model)
        {
            try
            {
                ChiTietDonHang m = JsonConvert.DeserializeObject<ChiTietDonHang>(model);

                var model_ = AutoMapper.Mapper.Map<LuuTruMaster>(m);
                var id_ = _iLuuTruMaster.Update(model_);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Create(string luutruModel)
        {
            try
            {
                LuuTruMaster m = JsonConvert.DeserializeObject<LuuTruMaster>(luutruModel);

                _iLuuTruMaster.Add(m);

                return Json(new { success = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Remove(long id)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var model =  db.LuuTruMaster.Find(id);
                    if (model != null)
                    {
                        db.LuuTruMaster.Remove(model);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "LuuTru");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}