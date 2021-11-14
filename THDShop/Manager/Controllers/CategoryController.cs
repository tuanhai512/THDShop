using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Controllers
{
    public class CategoryController : Controller
    {

        QLWBLTEntities _db = new QLWBLTEntities();
        // GET: NhanVien/LoaiMon
        public ActionResult Index()
        {
            if (Session["IDQL"] == null)
            {
                return RedirectToAction("Index", "LoginQuanLy");
            }
            return View(_db.Categories.ToList());
        }

        // GET: NhanVien/LoaiMon/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.Categories.Where(s => s.ID == id).FirstOrDefault());
        }

        // GET: NhanVien/LoaiMon/Create
        public ActionResult Create()
        {
            Category loai = new Category();
            return View(loai);
        }

        // POST: NhanVien/LoaiMon/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                // TODO: Add insert logic here
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/LoaiMon/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.Categories.Where(s => s.ID == id).FirstOrDefault());
        }

        // POST: NhanVien/LoaiMon/Edit/5
        [HttpPost]
        public ActionResult Edit(Category loai, int id)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _db.Entry(loai).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loai);
            }
            catch
            {
                return Content("Data đang được sử dụng bởi một bảng khác");
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_db.Categories.Where(s => s.ID == id).FirstOrDefault());
        }

        // POST: NhanVien/DonViTinhMon/Delete/5
        [HttpPost]
        public ActionResult Delete(Category category, int id)
        {
            try
            {
                // TODO: Add delete logic here
                category = _db.Categories.Where(s => s.ID == id).FirstOrDefault();
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Dữ liệu này đang được sử dụng bởi một bảng khác");
            }
        }

        public PartialViewResult LoaiPartial()
        {
            var loaiList = _db.Categories.ToList();
            return PartialView(loaiList);
        }
    }
}