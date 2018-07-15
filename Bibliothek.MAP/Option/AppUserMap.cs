using Bibliothek.Core.Map;
using Bibliothek.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.MAP.Option
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Name).HasMaxLength(30).IsRequired();
            Property(x => x.LastName).HasMaxLength(30).IsRequired();
            Property(x => x.Username).HasMaxLength(30).IsRequired();
            Property(x => x.Password).HasMaxLength(30).IsRequired();
            Property(x => x.Role).IsRequired();
            Property(x => x.Status).IsRequired();
        }
    }
}
