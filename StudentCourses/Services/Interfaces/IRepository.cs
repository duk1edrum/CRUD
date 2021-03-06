﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
   public interface IRepository<T>
   {
       IEnumerable<T> GetAll();
       T Get(int id);
       IEnumerable<T> Find(Func<T, Boolean> predicate);
       void Create(T item);
       void Update(T item);
       void Delete(int id);
   }
}
