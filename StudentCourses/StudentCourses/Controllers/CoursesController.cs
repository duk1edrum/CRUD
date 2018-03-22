using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Context;
using Data.Models;
using Data.ViewModels;

namespace StudentCourses.Controllers
{
    public class CoursesController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            var results = from s in db.Students
                          select new
                          {
                              s.StudentId,
                              s.Name,
                              s.LastName,
                              Checked = ((from ab in db.CoursesToStudents
                                          where (ab.CourseId == id) & 
                                                (ab.StudentId == s.StudentId)
                                          select ab).Count() > 0)
                          };

            var myViewModel = new CoursesViewModel();

            myViewModel.CourseId = id.Value;
            myViewModel.Name = course.Name;
            myViewModel.Room = course.Room;
            myViewModel.Free = course.Free;

            var myCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in results)
            {
                myCheckBoxList.Add(new CheckBoxViewModel
                {
                    Id = item.StudentId,
                    Name = item.Name + item.LastName,
                    Checked = item.Checked,

                });
            }

            myViewModel.Students = myCheckBoxList;

            return View(myViewModel);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            Course course = db.Courses.Create();
          //  if (course == null)
          //  {
          //      return HttpNotFound();
          //  }

            var results = from s in db.Students
                select new
                {
                    s.StudentId,
                    s.Name,
                    s.LastName,
                    Checked = ((from ab in db.CoursesToStudents
                                   where (ab.CourseId == course.CourseId) & (ab.StudentId == s.StudentId)
                                   select ab).Count() > 0)
                };

            var myViewModel = new CoursesViewModel();

            myViewModel.CourseId = course.CourseId;
            myViewModel.Name = course.Name;
            myViewModel.Room = course.Room;
            myViewModel.Free = course.Free;

            var myCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in results)
            {
                myCheckBoxList.Add(new CheckBoxViewModel
                {
                    Id = item.StudentId,
                    Name = item.Name + item.LastName,
                    Checked = item.Checked,

                });
            }

            myViewModel.Students = myCheckBoxList;

            return View();

        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Name,Room,Free")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            var results = from s in db.Students
                          select new
                          {
                              s.StudentId,
                              s.Name,
                              s.LastName,
                              Checked = ((from ab in db.CoursesToStudents
                                          where (ab.CourseId == id) & (ab.StudentId == s.StudentId)
                                          select ab).Count() > 0)
                          };

            var myViewModel = new CoursesViewModel();

            myViewModel.CourseId = id.Value;
            myViewModel.Name = course.Name;
            myViewModel.Room = course.Room;
            myViewModel.Free = course.Free;

            var myCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in results)
            {
                myCheckBoxList.Add(new CheckBoxViewModel
                {
                    Id = item.StudentId,
                    Name = item.Name + item.LastName,
                    Checked = item.Checked,

                });
            }

            myViewModel.Students = myCheckBoxList;

            return View(myViewModel);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CoursesViewModel course)
        {
            if (ModelState.IsValid)
            {
                var myCourse = db.Courses.Find(course.CourseId);
                myCourse.Name = course.Name;
                myCourse.Room = course.Room;
                myCourse.Free = course.Free;

                foreach (var item in db.CoursesToStudents)
                {
                    if (item.CourseId == course.CourseId)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in course.Students)
                {
                    if (item.Checked)
                    {
                        db.CoursesToStudents.Add(
                            new CourseToStudent() { CourseId = course.CourseId, StudentId = item.Id });

                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
