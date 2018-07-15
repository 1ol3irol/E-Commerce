using Bibliothek.Core.Map;
using Bibliothek.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.MAP.Option
{
    public class CustomerMap:CoreMap<Customer>
    {
        public CustomerMap()
        {
            ToTable("dbo.Customers");
            Property(x => x.Name).HasMaxLength(30).IsRequired();
            Property(x => x.LastName).HasMaxLength(30).IsRequired();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(30).IsRequired();
            Property(x => x.Phone).IsOptional();
            Property(x => x.Address).HasMaxLength(150).IsOptional();
        }
    }
}
