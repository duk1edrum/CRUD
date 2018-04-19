using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Data.Context;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Service.DTO;
using Service.Interfaces;
using Service.Services;
using StudentCourses.Mapping;
using StudentCourses.ViewModels;

namespace StudentCourses.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;

        private StudentContext _db = new StudentContext();


        public UsersController()
        {
            _userService = new UserService();
        }

        // GET: Users
        public ActionResult Index()
        {

            IEnumerable<UserDto> userDtos = _userService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDto, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDto>, List<UserViewModel>>(userDtos);
            return View(users.ToList());
        }

        public ActionResult Details(int? id)
        {
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

            return View();
            //    }
        }

        // Create
        // GET: 
        [HttpGet]
        public ActionResult Create(int? id)
        {
            UserViewModel userView = new UserViewModel();
            if (id.HasValue && id != 0)
            {
                UserDto userDto = _userService.GetUser(id.Value);
                UserViewMapping.ToUserView(userDto);
            }
            return View(userView);
        }

        //Create:
        //POST:
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserViewModel userView)
        {
            
                var userEntity = UserViewMapping.ToUserDto(userView);
                _userService.Create(userEntity);

                
            
            _userService.Save();

            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            //UserDto userDto = _userService.GetUser(id);
            UserViewModel userView = new UserViewModel();
            if (id.HasValue && id != 0)
            {
                UserViewModel userEntity = UserViewMapping.ToUserView(_userService.GetUser(id));
            }
            return View();
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,LastName,Login,Password")] UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
               // UserDto userDto = _userService.GetUser(id.Value);
               // UserViewMapping.ToUserView(userDto);
            }
            return View(userView);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _userService.Delete(id);
            //if (userView == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _userService.Delete(id);
            _userService.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    UserService.Dispose();
        //    base.Dispose(disposing);
        //}
    }

    internal interface IShowUsers<T>
    {
    }
}
