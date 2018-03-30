using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Services.Interfaces
{
   public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Student> Students { get; }
        void Save();
    }
}
