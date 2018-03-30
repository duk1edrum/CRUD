using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data.Context;
using Data.Models;
using Services.Interfaces;

namespace Services.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly StudentContext _db;

        public UserRepository(StudentContext context)
        {
            this._db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }
        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            if (user != null)
                _db.Users.Remove(user);
        }


    }
}
