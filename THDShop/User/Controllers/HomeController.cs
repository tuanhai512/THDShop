﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace User.Controllers
{
    public class HomeController : Controller
    {
        private QLLaptopShopEntities _context = new QLLaptopShopEntities();

        public ActionResult Index()
        {
            var model = _context.PRODUCTS.ToList();
            return View(model);
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