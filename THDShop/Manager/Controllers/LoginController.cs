using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        QLLaptopShopEntities database = new QLLaptopShopEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAccount(USERS _user)
        {
            STAFF sTAFF = database.STAFF.Where(m => m.ID == _user.ID).FirstOrDefault();
            CUSTOMER cUSTOMER = database.CUSTOMER.Where(m => m.ID == _user.ID).FirstOrDefault();
            
            if (!CheckExistAccount(_user))
            {
                ViewBag.ErrorInfo = "Sai info";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["EMAIL"] = _user.EMAIL;
                Session["PASSWORD"] = _user.PASSWORD;
                if(_user.ID == sTAFF.IDUSER || sTAFF.ROLES.NAME == "Manager" )
                {
                    Session["TENNV"] = sTAFF.NAME;
                    Session["ID"] = sTAFF.ID;

                }
                else if (_user.ID == sTAFF.IDUSER || sTAFF.ROLES.NAME == "Staff")
                {
                    Session["TENKH"] = cUSTOMER.NAME;
                    Session["ID"] = cUSTOMER.ID;
                }    
               
                return RedirectToAction("Index", "MonAn");
            }

        }
        public ActionResult EditAccount(int ID)
        {
            var detailUser = database.USERS.Where(m => m.ID == ID).FirstOrDefault();
            return View(detailUser);
        }

        [HttpPost]
        public ActionResult EditAccount(USERS user)
        {
            var detail = database.USERS.Where(m => m.ID == user.ID);

            if (detail == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                database.Entry(user).State = EntityState.Modified;
                database.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public bool CheckExistAccount(USERS _user)
        {

            var check = database.USERS.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();
            if (check != null)
            {
                return true;
            }
            return false;
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginUser");
        }
    }
}
