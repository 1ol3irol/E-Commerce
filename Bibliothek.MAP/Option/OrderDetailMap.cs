using Bibliothek.Core.Map;
using Bibliothek.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.MAP.Option
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(x => x.Price).IsOptional();
            Property(x => x.Quantity).IsOptional();
        }
    }
}
