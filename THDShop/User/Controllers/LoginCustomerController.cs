using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User.Controllers
{
    public class LoginCustomerController : Controller
    {
        // GET: Login
        private QLLaptopShopEntities _db = new QLLaptopShopEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(USERS _user)
        {

            var check = _db.USERS.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai info";
                return View("Login");
            }
            else
            {
                _db.Configuration.ValidateOnSaveEnabled = false;
                Session["EMAIL"] = _user.EMAIL;
                Session["PASSWORD"] = _user.PASSWORD;
                Session["MaKH"] = check.ID;
                int a = (int)Session["MaKH"];
                return RedirectToAction("Index", "Home");
            }
            //return View();
        }
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(USERS _user)
        {
          
            if (ModelState.IsValid)
            {
               
                var check_ID = _db.USERS.Where(s => s.EMAIL == _user.EMAIL).FirstOrDefault();
                var check_IDCUS = _db.CUSTOMER.Where(s => s.EMAIL == _user.EMAIL).FirstOrDefault();

                if (check_ID == null )
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.USERS.Add(_user);

                    var _cus = new CUSTOMER()
                    {
                        EMAIL = _user.EMAIL,
                        PHONE = _user.PHONE,
                        PASSWORD = _user.PASSWORD,
                        NAME = _user.NAME,
                        ADDRESS = _user.ADDRESS,
                    };

                    _db.CUSTOMER.Add(_cus);
                    _db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist";
                    return View();
                }
            }
            return View();
        }
        public ActionResult EditAccount(int ID)
        {
            var detailUser = _db.CUSTOMER.Where(m => m.ID == ID).FirstOrDefault();
            return View(detailUser);
        }

        [HttpPost]
        public ActionResult EditAccount(CUSTOMER khachhang)
        {
            var detail = _db.CUSTOMER.Where(m => m.ID == khachhang.ID);

            if (detail == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Entry(khachhang).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public bool CheckExistAccount(CUSTOMER khachang)
        {
            var check = _db.CUSTOMER.Where(s => s.EMAIL == khachang.EMAIL && s.PASSWORD == khachang.PASSWORD).FirstOrDefault();
            if (check != null)
            {
                return true;
            }

            return false;
        }
        public ActionResult Order(int id)
        {
            var bill = _db.BILL.Where(m => m.ORDERS.DELI_ADDRESS.IDCUSTOMER == id).ToList();
            return View(bill);
        }
    }
}
