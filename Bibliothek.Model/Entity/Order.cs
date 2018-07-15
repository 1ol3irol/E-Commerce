using Bibliothek.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.Model.Entity
{
    public class Order:CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public Guid CustomerID { get; set; }
        public string ShipAddress { get; set; }
        public virtual Customer Customer { get; set; }
        public bool Confirmed { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
