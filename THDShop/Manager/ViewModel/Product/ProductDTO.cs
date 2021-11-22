using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manager.ViewModel.Product
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public int? IDCATEGORY { get; set; }
        public string NAME { get; set; }
        public int QUANTITY { get; set; }
        public double PRICE { get; set; }
        public double ORI_PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMAGE { get; set; }
        public string CATEGORYNAME { get; set; }
    }
}