using Bibliothek.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.Model.Entity
{
    public class Comment:CoreEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
