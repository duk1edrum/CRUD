using Data.Context;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
   public  class StudentRepository : IRepository<Student>
    {

        private StudentContext _db;

       
        public StudentRepository (StudentContext context)
        {
            this._db = new StudentContext("CrudDb");
        }

        public StudentRepository()
        {
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Students;
        }

        public Student Get(int? id)
        {
            return _db.Students.Find(id);
        }

        public void Create(Student student )
        {
            _db.Students.Add(student);
        }

        public void Update(Student student)
        {
            _db.Entry(student).State = System.Data.Entity.EntityState.Modified;
        }

        //public IEnumerable<Student> Find(Func<Student,Boolean> predicate)
        //{
        //    return _db.Students.Where(predicate).ToList();
        //}

        public void Delete(int id)
        {
            Student student = _db.Students.Find(id);
            if (student != null)
                _db.Students.Remove(student);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
