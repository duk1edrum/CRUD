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
using StudentCourses.Mapping;
using StudentCourses.ViewModels;

namespace StudentCourses.Controllers
{

    public class StudentsController : Controller
    {
        private IStudentService _studentService;

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

            return View(students.ToList());

        }

        //GET: Students/Details
        public ActionResult Details(int? id)
        {
            StudentDTO studentDTO = _studentService.GetStudent(id);
            var viewStudent = StudentViewMapping.ToStudentView(studentDTO);

            return View(viewStudent);
        }
       

        //GET: Students/Create
        public ActionResult Create(int? id)
        {
            StudentViewModel studentView = new StudentViewModel();
            if (id.HasValue && id != 0)
            {
                StudentDTO studentDTO = _studentService.GetStudent(id);
            }

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //  more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentView)
        {

            if (ModelState.IsValid)
            {
                var studentEntity = StudentViewMapping.ToStudentDTO(studentView);
                _studentService.Create(studentEntity);
             
                return RedirectToAction("Index");
            }

            return View(studentView);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            StudentViewModel studentView = StudentViewMapping.ToStudentView(_studentService.GetStudent(id));

            return View(studentView);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentView)
        {
            if (ModelState.IsValid)
            {
                var dto = studentView.ToStudentDTO();
                _studentService.Update(dto);
                return RedirectToAction("Index");
            }
            return View(studentView);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            var dto = _studentService.GetStudent(id);
            var view = StudentViewMapping.ToStudentView(dto);
            return View(view);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("Index");
        }

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
}
