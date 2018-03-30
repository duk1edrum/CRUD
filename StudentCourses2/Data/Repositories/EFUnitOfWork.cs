using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Interfaces;
using Data.Models;

namespace Data.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private StudentContext db;

        private UserRepository _userRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new StudentContext(connectionString);
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
