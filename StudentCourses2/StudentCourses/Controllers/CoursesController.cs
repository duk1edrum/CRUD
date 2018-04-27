using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Service.DTO;
using Service.Interfaces;
using Service.Services;
using StudentCourses.Mapping;
using StudentCourses.ViewModels;

namespace StudentCourses.Controllers
{

    public class CoursesController : Controller
    {
        private ICourseService _courseService;

        public CoursesController()
        {
            this._courseService = new CourseService();
        }

        // GET: Courses
        public ActionResult Index()
        {
            IEnumerable<CourseDTO> courseDTO = _courseService.GetCourses();
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<CourseDTO, CourseViewModel>()).CreateMapper();
            var courses = mapper.Map<IEnumerable<CourseDTO>, List<CourseViewModel>>(courseDTO);
            return View(courses.ToList());
        }

        //GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            CourseDTO courseDTO = _courseService.GetCourse(id);

            var viewCourse = CourseViewMapping.ToCourseView(courseDTO);

            return View(viewCourse);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            CourseViewModel courseView = new CourseViewModel();

            return View();

        }
        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel courseView)
        {
            if (ModelState.IsValid)
            {
                var view = CourseViewMapping.ToCourseDTO(courseView);
                _courseService.Create(view);
                return RedirectToAction("Index");
            }

            return View(courseView);
        }

        //GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {

            var findId = _courseService.GetCourse(id);
            var view = CourseViewMapping.ToCourseView(findId);
            return View(view);
        }

        //POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel courseView)
        {
            if (ModelState.IsValid)
            {
                var dto = courseView.ToCourseDTO();
                _courseService.Update(dto);
                return RedirectToAction("Index");
            }
            return View(courseView);
        }

        //GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {

            var dto = _courseService.GetCourse(id);
            var view = CourseViewMapping.ToCourseView(dto);
            return View(view);
        }

        //POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _courseService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {


        }
    }
}




//        

//       

//       

//        

//       

//       

//

//       
//    }
//}
