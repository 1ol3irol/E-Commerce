using Bibliothek.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.Model.Entity
{
    public class Product:CoreEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public string Quantity { get; set; }
        public string Director { get; set; }
        public string Star { get; set; }
        public string Artist { get; set; }
        public string TradeMark { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
