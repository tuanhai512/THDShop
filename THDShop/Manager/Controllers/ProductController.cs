using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager.ViewModel.Product;

namespace Manager.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private QLLaptopShopEntities _context = new QLLaptopShopEntities();
       

       
        public ActionResult Index()
        {
            if (Session["IDQL"] == null)
            {
                return RedirectToAction("Index", "LoginQuanLy");
            }
            var query = ProductSingleton.Instance.listProduct;
            return View(query.ToList());          
        }

        public ActionResult Create()
        {
            var categorylist = _context.PRODUCTS.ToList().Select(
            x => new SelectListItem
            {
                Text = x.NAME,
                Value = Convert.ToString(x.ID)
            }
           );
            ViewBag.Categories = categorylist;
            return View();

        }
        [HttpPost]
        public ActionResult Create(CreateProductInput model)
        {
            var entity = new PRODUCTS();
            if (model != null)
            {
                entity = new PRODUCTS();
                var categorylist = _context.CATEGORIES.ToList().Select(
                x => new SelectListItem
                {
                    Text = x.NAME,
                    Value = Convert.ToString(x.ID)
                }
                );
                ViewBag.Categories = categorylist;
                if (model.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                    string extent = Path.GetExtension(model.UploadImage.FileName);
                    filename = filename + extent;
                    model.Image = "/Images/" + filename;
                    model.UploadImage.SaveAs(Path.Combine("../Manager/Assets/img/" + filename));
                    model.UploadImage.SaveAs(Path.Combine("../User/Assets/img/" + filename));
                }
                entity.IMAGE = model.Image;
                if (ModelState.IsValid)
                {
                    entity.ID = model.Id;
                    entity.NAME = model.Name;
                    entity.PRICE = model.Price.HasValue ? model.Price.Value : 0;
                    entity.QUANTITY = model.Quantity.HasValue ? model.Quantity.Value : 0;
                    entity.DESCRIPTION = model.Description;
                    entity.IDCATEGORY = model.CategoryId;
                    _context.PRODUCTS.Add(entity);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {

                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {

            var entity = _context.PRODUCTS.Find(id);
            var model = new UpdateProductInput();
            var categorylist = _context.CATEGORIES.ToList();
            ViewBag.Categories = new SelectList(categorylist, "Name", "Name");

            model.Id = entity.ID;
            model.Name = entity.NAME;
            model.Price = entity.PRICE;
            model.Quantity = entity.QUANTITY;
            model.Description = entity.DESCRIPTION;

            model.CategoryId = entity.IDCATEGORY;
            model.Image = entity.IMAGE;
            return View(model);
        }
        [HttpPut]
        public ActionResult Edit(UpdateProductInput model)
        {
            var entity = new PRODUCTS();
            if (model == null)
                return HttpNotFound();

            var categorylist = _context.CATEGORIES.ToList();
            ViewBag.Categories = new SelectList(categorylist, "Name", "Name");

            if (model.UploadImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                string extent = Path.GetExtension(model.UploadImage.FileName);
                filename = filename + extent;
                model.Image = "/Images/" + filename;

                model.UploadImage.SaveAs(Path.Combine("../Manager/Assets/img/" + filename));
                model.UploadImage.SaveAs(Path.Combine("../User/Assets/img/" + filename));
            }
            entity.ID = model.Id;
            entity.NAME = model.Name;
            entity.PRICE = model.Price.HasValue ? model.Price.Value : 0;
            entity.QUANTITY = model.Quantity.HasValue ? model.Quantity.Value : 0;
            entity.DESCRIPTION = model.Description;
            entity.IDCATEGORY = model.CategoryId;
            entity.IMAGE = model.Image;

            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var entity = this._context.PRODUCTS.Find(id);
            this._context.PRODUCTS.Remove(entity);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(DetailProductDTO model, int id)
        {
            var query = from c in _context.PRODUCTS
                        where c.ID == id
                        select new DetailProductDTO
                        {
                            ID = c.ID,
                            NAME = c.NAME,
                            PRICE = c.PRICE,
                            QUANTITY = c.QUANTITY,
                            DESCRIPTION = c.DESCRIPTION,
                            IMAGE = c.IMAGE,
                            CATEGORYNAME = c.CATEGORIES.NAME
                        };

            return View(query.First());
        }
    }
}