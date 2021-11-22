using Manager.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User.Controllers
{
    public class HomeUserController : Controller
    {
        QLLaptopShopEntities _db = new QLLaptopShopEntities();


        public ActionResult Index()
        {
            var prodList = _db.PRODUCTS.OrderByDescending(x => x.NAME);
            return View(prodList);
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