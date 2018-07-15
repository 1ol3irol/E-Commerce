using Bibliothek.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliothek.UI.Areas.Admin.Models.VM
{
    public class OrderVM
    {
        public OrderVM()
        {
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
        }
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}