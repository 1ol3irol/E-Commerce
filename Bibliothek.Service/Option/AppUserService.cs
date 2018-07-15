using Bibliothek.Model.Entity;
using Bibliothek.Service.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.Service.Option
{
    public class AppUserService:ServiceBase<AppUser>
    {
        public bool CheckCredentials(string userName, string password)
        {
            return Any(x => x.Username == userName && x.Password == password);
        }

        public AppUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.Username == userName);
        }
    }
}
