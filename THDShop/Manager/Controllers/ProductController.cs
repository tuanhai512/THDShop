using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager.ViewModel.Product;
using Manager.ViewModel.Category;


namespace Manager.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private QLLaptopShopEntities _context=new QLLaptopShopEntities();
        public ProductController()
        {
            ProductSingleton.Instance.Init(_context);
        } 


        //public ProductController(QLLaptopShopEntities context)
        //{
        //    this._context = context;
        //    //  this._webHostEnvironment = webHostEnvironment;
        //    ProductSingleton.Instance.Init(context);

        //}
        public ActionResult Index()
        {
            var query = from c in _context.PRODUCTS
                        select new ProductDTO
                        {
                            ID = c.ID,
                            NAME = c.NAME,
                            PRICE = c.PRICE,
                            ORI_PRICE = c.ORI_PRICE,
                            DESCRIPTION = c.DESCRIPTION,
                            CATEGORYNAME = c.CATEGORy.NAME,
                            IDCATEGORY = c.IDCATEGORY,
                            QUANTITY = c.QUANTITY,
                            IMAGE = c.IMAGE
                        };
            return View(query.ToList());
            //var query = ProductSingleton.Instance.listProduct;
            //return View(query.ToList());
        }

        public ActionResult Create()
        {
            var categorylist = _context.CATEGORIES.ToList().Select(
            x => new SelectListItem
            {
                Text = x.NAME,
                Value = Convert.ToString(x.ID)
            }
           );
            ViewBag.Categories = categorylist;
            CreateProductInput prod = new CreateProductInput();
            return View(prod);

        }
        [HttpPost]
        public ActionResult Create(CreateProductInput model)
        {
            var entity = new PRODUCT();
            if (model != null)
            {
                entity = new PRODUCT();
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
                    model.IMAGE = "~/Assets/Images/" + filename;
                    model.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Assets/Images") , filename));
                }
                entity.IMAGE = model.IMAGE; 
                if (ModelState.IsValid)
                {
                    entity.ID = model.ID;
                    entity.NAME = model.NAME;
                    entity.PRICE = model.PRICE.HasValue ? model.PRICE.Value : 0;
                    entity.ORI_PRICE = model.ORI_PRICE.HasValue ? model.ORI_PRICE.Value : 0;
                    entity.QUANTITY = model.QUANTITY.HasValue ? model.QUANTITY.Value : 0;
                    entity.DESCRIPTION = model.DESCRIPTION;
                    entity.IDCATEGORY = model.IDCATEGORY;
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
        public ActionResult Edit(int ID)
        {

            var entity = _context.PRODUCTS.Find(ID);
            var model = new UpdateProductInput();
            var categorylist = _context.CATEGORIES.ToList();
            ViewBag.Categories = new SelectList(categorylist, "NAME", "NAME");

            model.ID = entity.ID;
            model.NAME = entity.NAME;
            model.PRICE = entity.PRICE;
            model.ORI_PRICE = entity.ORI_PRICE;
            model.QUANTITY = entity.QUANTITY;
            model.DESCRIPTION = entity.DESCRIPTION;
            model.IDCATEGORY = entity.IDCATEGORY;
            model.IMAGE = entity.IMAGE;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UpdateProductInput model)
        {
            var entity = new PRODUCT();
            if (model == null)
                return HttpNotFound();

            var categorylist = _context.CATEGORIES.ToList();
            ViewBag.Categories = new SelectList(categorylist, "NAME", "NAME");

            if (model.UploadImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                string extent = Path.GetExtension(model.UploadImage.FileName);
                filename = filename + extent;
                model.IMAGE = "/Images/" + filename;
                model.UploadImage.SaveAs(Path.Combine("~/Assets/Images/" + filename));
            }
            entity.ID = model.ID;
            entity.NAME = model.NAME;
            entity.PRICE = model.PRICE.HasValue ? model.PRICE.Value : 0;
            entity.ORI_PRICE = model.ORI_PRICE.HasValue ? model.ORI_PRICE.Value : 0;
            entity.QUANTITY = model.QUANTITY.HasValue ? model.QUANTITY.Value : 0;
            entity.DESCRIPTION = model.DESCRIPTION;
            entity.IDCATEGORY = model.IDCATEGORY;
            entity.IMAGE = model.IMAGE;

            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int ID)
        {
            var entity = this._context.PRODUCTS.Find(ID);
            ProductSingleton.Instance.listProduct.Clear();
            ProductSingleton.Instance.Init(_context);
            this._context.PRODUCTS.Remove(entity);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Detail(DetailProductDTO model, int ID)
        //{
        //    var query = from c in _context.PRODUCTS
        //                where c.ID == ID
        //                select new DetailProductDTO
        //                {
        //                    ID = c.ID,
        //                    NAME = c.NAME,
        //                    PRICE = c.PRICE,
        //                    QUANTITY = c.QUANTITY,
        //                    DESCRIPTION = c.DESCRIPTION,
        //                    IMAGE = c.IMAGE,
        //                    CATEGORYNAME = c.CATEGORy.NAME
        //                };

        //    return View(query.First());
        //}
    }
}