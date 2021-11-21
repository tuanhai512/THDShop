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
            PRODUCT product = new PRODUCT();
            var query = from c in _db.PRODUCTS
                        select new ProductDTO
                        {
                            ID = c.ID,
                            NAME = c.NAME,
                            PRICE = c.PRICE,
                            QUANTITY = c.QUANTITY                         
                        };
            return View(query.ToList());
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