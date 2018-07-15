using Bibliothek.Core.Entity;
using Bibliothek.Core.Enum;
using Bibliothek.Core.Service;
using Bibliothek.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.Service.Main
{
    public class ServiceBase<T>:ICoreService<T> where T:CoreEntity
    {
        private static ProjectContext _context;

        public ProjectContext context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ProjectContext();
                    return _context;
                }
                return _context;
            }
            set { _context = value; }
        }


        protected DbSet<T> table;

        public ServiceBase()
        {
            context = new ProjectContext();
            table = _context.Set<T>();
        }

        public void Add(List<T> items)
        {
            table.AddRange(items);
            Save();
        }

        public void Add(T item)
        {
            table.Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) =>
            table.Any(exp);


        public List<T> GetActive() =>
            table.Where(x => x.Status == Status.Active).ToList();


        public List<T> GetAll() =>
            table.ToList();

        //Find metodu
        public T GetByDefault(Expression<Func<T, bool>> exp) =>
            table.Where(exp).FirstOrDefault();


        public T GetByID(Guid id) =>
            table.Find(id);


        //Listeleme metodu-List ismi ver
        public List<T> GetDefault(Expression<Func<T, bool>> exp) =>
            table.Where(exp).ToList();


        public void Remove(Guid id)
        {
            T item = GetByID(id);
            item.Status = Status.Deleted;
            Update(item);
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public int Save() =>
            context.SaveChanges();

        public void Update(T item)
        {
            T updated = GetByID(item.ID);
            DbEntityEntry entry = context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

        public void DetachEntity(T item)
        {
            context.Entry<T>(item).State = EntityState.Detached;
        }
    }
}
