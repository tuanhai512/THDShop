using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Manager.ViewModel.Product;

namespace User.ViewModel
{
    public class HomeUserSingleton
    {
        public static HomeUserSingleton Instance { get; } = new HomeUserSingleton();
        public List<ProductDTO> listProduct { get; } = new List<ProductDTO>();
        private HomeUserSingleton() { }

        public void Init(QLLaptopShopEntities _db)
        {
            if (listProduct.Count == 0)
            {
                var query = from c in _db.PRODUCTS
                            select new ProductDTO
                            {
                                ID = c.ID,
                                NAME = c.NAME,
                                PRICE = c.PRICE,
                                DESCRIPTION = c.DESCRIPTION,
                                CATEGORYNAME = c.CATEGORY.NAME,
                                IDCATEGORY = c.IDCATEGORY,
                                QUANTITY = c.QUANTITY,
                                IMAGE = c.IMAGE
                            };
                foreach (var item in query)
                {
                    listProduct.Add(item);
                }
            }
        }
    }
}