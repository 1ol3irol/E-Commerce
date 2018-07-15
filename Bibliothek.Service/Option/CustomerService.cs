using Bibliothek.Model.Entity;
using Bibliothek.Service.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.Service.Option
{
    public class CustomerService:ServiceBase<Customer>
    {
        public bool CheckCredentials(string email, string password)
        {
            return Any(x => x.Email == email && x.Password == password);
        }

        public Customer FindByID(Guid id)
        {
            return GetByDefault(x => x.ID == id);
        }
    }
}
