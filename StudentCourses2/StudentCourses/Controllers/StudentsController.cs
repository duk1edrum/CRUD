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
using Data.Repositories;
using Service.DTO;
using Service.Interfaces;
using Service.Services;
using StudentCourses.ViewModels;

namespace StudentCourses.Controllers
{
    //public class StudentController : Controller
    //{
    //    IStudentService _studentService;

    //    public StudentController(IStudentService service)
    //    {
    //        _studentService = service;
    //    }

    //    public ActionResult Index()
    //    {
    //        IEnumerable<StudentDTO> studentDtos = _studentService.GetStudents();
    //        var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
    //        var students = mapper.Map<IEnumerable<StudentDTO>, List<StudentViewModel>>(studentDtos);
    //        return View(students);
    //    }

    //}
}
public class StudentsController : Controller
{
    IStudentService _studentService;

    public StudentsController()
    {
        this._studentService = new StudentService();
    }


    // GET: Students
    public ActionResult Index()
    {

        IEnumerable<StudentDTO> studentDtos = _studentService.GetStudents();
        var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
        var students = mapper.Map<IEnumerable<StudentDTO>, List<StudentViewModel>>(studentDtos);
        return View(students);
        //return View(db.Students.ToList());
    }

    // GET: Students/Details/5
    //public ActionResult Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Student student = db.Students.Find(id);
    //    if (student == null)
    //    {
    //        return HttpNotFound();
    //    }

    //    var results = from c in db.Courses
    //                  select new
    //                  {
    //                      c.Id,
    //                      c.Name,
    //                      c.Room,
    //                      Checked = ((from ab in db.Courses
    //                                  where (ab.Id == id) &
    //                                        (ab.Id == c.Id)
    //                                  select ab).Any())
    //                  };

    //    var myViewModel1 = new StudentsViewModel();

    //    myViewModel1.StudentId = id.Value;
    //    myViewModel1.Name = student.Name;
    //    myViewModel1.LastName = student.LastName;
    //    myViewModel1.Stipend = student.Stipend;
    //    myViewModel1.SizeStipend = student.SizeStipend;

    //    var myCheckboxList = new List<CheckBoxViewModel>();

    //    foreach (var item in results)
    //    {
    //        myCheckboxList.Add(new CheckBoxViewModel
    //        {
    //            Id = item.Id,
    //            Name = item.Name,
    //            Checked = item.Checked,
    //        });
    //    }

    //    myViewModel1.Courses = myCheckboxList;

    //return View(myViewModel1);
    //    }

    // GET: Students/Create
    public ActionResult Create()
    {


        return View();
    }

    // POST: Students/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create([Bind(Include = "StudentId,Name,LastName,Stipend,Amount")] Student student)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _studentService..Add(student);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    return View(student);
    //}

    //    // GET: Students/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Student student = db.Students.Find(id);
    //        if (student == null)
    //        {
    //            return HttpNotFound();
    //        }

    //        //var results = from c in db.Courses
    //        //    select new
    //        //    {
    //        //        c.CourseId,
    //        //        c.Name,
    //        //        c.Room,
    //        //        Checked = ((from ab in db.CoursesToStudents
    //        //                       where (ab.StudentId == id) &
    //        //                             (ab.CourseId == c.CourseId)
    //        //                       select ab).Count() > 0)
    //        //    };

    //        var myViewModel1 = new StudentsViewModel();

    //        myViewModel1.StudentId = id.Value;
    //        myViewModel1.Name = student.Name;
    //        myViewModel1.LastName = student.LastName;
    //        myViewModel1.Stipend = student.Stipend;
    //        myViewModel1.SizeStipend = student.SizeStipend;

    //        var myCheckboxList = new List<CheckBoxViewModel>();

    //        //foreach (var item in results)
    //        //{
    //        //    myCheckboxList.Add(new CheckBoxViewModel
    //        //    {
    //        //        Id = item.CourseId,
    //        //        Name = item.Name,
    //        //        Checked = item.Checked,
    //        //    });
    //        //}

    //        myViewModel1.Courses = myCheckboxList;

    //        return View(myViewModel1);
    //    }

    //    // POST: Students/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(StudentsViewModel student)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var myStudent = db.Students.Find(student.StudentId);
    //            myStudent.Name = student.Name;
    //            myStudent.LastName = student.LastName;
    //            myStudent.Stipend = student.Stipend;
    //            myStudent.SizeStipend = student.SizeStipend;

    //            //foreach (var item in db.CoursesToStudents)
    //            //{
    //            //    if (item.StudentId == student.StudentId)
    //            //    {
    //            //        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
    //            //    }
    //            //}

    //            //foreach (var item in student.Courses)
    //            //{
    //            //    if (item.Checked)
    //            //    {
    //            //        db.CoursesToStudents.Add(
    //            //            new CourseToStudent() {StudentId = student.StudentId, CourseId = item.Id});
    //            //    }
    //            //}

    //            // db.Entry(student).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(student);
    //    }

    //    // GET: Students/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Student student = db.Students.Find(id);
    //        if (student == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(student);
    //    }

    //    // POST: Students/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Student student = db.Students.Find(id);
    //        db.Students.Remove(student);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}
}
