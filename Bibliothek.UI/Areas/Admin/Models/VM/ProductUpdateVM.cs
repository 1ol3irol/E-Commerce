using Bibliothek.Model.Entity;
using Bibliothek.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliothek.UI.Areas.Admin.Models.VM
{
    public class ProductUpdateVM
    {
        public ProductUpdateVM()
        {
            Categories = new List<Category>();
            Product = new ProductDTO();
        }

        public List<Category> Categories { get; set; }
        public ProductDTO Product { get; set; }
    }
}