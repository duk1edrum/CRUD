using Data.Context;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class CourseRepository:IRepository<Course>
    {
        private StudentContext _db;

        public CourseRepository(StudentContext context)
        {
            this._db = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _db.Courses.Include(o => o.Students);
        }

        public Course Get(int? id)
        {
            return _db.Courses.Find(id);
        }

        public void Create(Course course)
        {
            _db.Courses.Add(course);
        }

        public void Update(Course course)
        {
            _db.Entry(course).State = EntityState.Modified;
        }

        public IEnumerable<Course> Find (Func<Course,Boolean> predicate)
        {
            return _db.Courses.Include(o => o.Students).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Course course = _db.Courses.Find(id);
            if (course != null)
                _db.Courses.Remove(course);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }

}
