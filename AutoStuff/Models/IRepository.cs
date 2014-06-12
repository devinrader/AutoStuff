using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStuff.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> Select();
        void Insert(T entity);
        void Delete(int ID);
        void Update(T entity);
        void Save();
    }
}