using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        QLLaptopShopEntities database = new QLLaptopShopEntities();
        public ActionResult Index()
        {
            if (Session["IDQL"] == null)
            {
                return RedirectToAction("Index", "LoginQuanLy");
            }
            return View(database.ROLES.ToList());
        }

        // GET: QuanLy/KhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View(database.ROLES.Where(s => s.ID == id).FirstOrDefault());
        }

        // GET: QuanLy/KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLy/KhachHang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLy/KhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View(database.ROLES.Where(s => s.ID == id).FirstOrDefault());
        }

        // POST: QuanLy/Account/Edit/5
        [HttpPost]
        public ActionResult Edit(ROLES role)
        {
            var detail = database.ROLES.Where(s => s.ID == role.ID);

            if (detail == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                database.Entry(role).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: QuanLy/KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuanLy/KhachHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
    }
}