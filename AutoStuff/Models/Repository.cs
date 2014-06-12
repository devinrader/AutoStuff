using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStuff.Models
{
    public class Repository<T> : IRepository<T>
    {
        public List<T> _entities;

        public Repository()
        {
            _entities = new List<T>();
        }

        public IEnumerable<T> Select()
        {
            return _entities;
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public virtual void Delete(int ID)
        {
        }

        public virtual void Update(T entity)
        {
        }

        public virtual void Save()
        {
        }
    }
}