using Bibliothek.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.Model.Entity
{
    public class OrderDetail:CoreEntity
    {
        public virtual Order Order { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
        public Guid OrderID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
