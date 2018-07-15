using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliothek.UI.Areas.Admin.Models.DTO
{
    public class ProductDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public string Quantity { get; set; }
        public string Director { get; set; }
        public string Star { get; set; }
        public string Artist { get; set; }
        public string TradeMark { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public Guid CategoryID { get; set; }
    }
}