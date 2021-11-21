using System;
using Manager.ViewModel.Product;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User;
using System.Web.Mvc;
using User.ViewModel;

namespace User.Controllers
{
    public class HomeUserController : Controller
    {
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        public HomeUserController()
        {

        }
        public ActionResult Index()
        {
            var prodList = _db.PRODUCTS.OrderByDescending(x => x.NAME);
            return View(prodList);
        }

        public ActionResult Details(int id)
        {
            return View(_db.PRODUCTS.Where(s => s.ID == id).FirstOrDefault());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}