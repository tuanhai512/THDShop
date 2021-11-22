using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User.ViewModel;

namespace User.Controllers
{
    public class CartController : Controller
    {
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var product = _db.PRODUCTS.SingleOrDefault(s => s.ID == id);
            if (product != null)
            {
                GetCart().Add_Product_Cart(product);
            }
            return RedirectToAction("ShowToCart", "Cart");
        }
        // GET: Cart
        public ActionResult ShowToCart()
        {
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult UpdateCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_product = int.Parse(form["ID_PRODUCT"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_quantity(id_product,quantity);
            return RedirectToAction("ShowToCart","Cart");
        }
    }
}