using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manager.ViewModel.Product
{
    public class ProductSingleton
    {
        public static ProductSingleton Instance { get; } = new ProductSingleton();
        public List<ProductDTO> listProduct { get; } = new List<ProductDTO>();
        private ProductSingleton() { }

        public void Init(QLLaptopShopEntities _context)
        {
            if (listProduct.Count == 0)
            {
                var query = from c in _context.PRODUCTS
                            select new ProductDTO
                            {
                                ID = c.ID,
                                NAME = c.NAME,
                                PRICE = c.PRICE,
                                DESCRIPTION = c.DESCRIPTION,
                                CATEGORYNAME = c.CATEGORIES.NAME,
                                CategoryId = c.IDCATEGORY,
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