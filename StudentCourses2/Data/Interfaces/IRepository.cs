using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        //IEnumerable<T> Find(Func<T, Boolean> predicate);

        void Create(T item);
        void Update(T item);
        void Delete(int id);
      
    }
}
