using Bibliothek.Core.Map;
using Bibliothek.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.MAP.Option
{
    public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");

            HasRequired(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.OrderDetails)
            .WithRequired(x => x.Order)
            .HasForeignKey(x => x.OrderID)
            .WillCascadeOnDelete(false);
        }
    }
}
