﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Data.Models;
using Service.DTO;
using Service.Interfaces;
using Service.Services;
using StudentCourses.ViewModels;

namespace StudentCourses.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;


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

        // Create
        // GET: 
        [HttpGet]
        public ActionResult Create(int? id)
        {
            UserViewModel userView = new UserViewModel();
            if (id.HasValue && id != 0)
            {
                UserDto userDto = _userService.GetUser(id.Value);
                userView.Name = userDto.Name;
                userView.LastName = userDto.LastName;
                userView.Email = userDto.Login;
                userView.Password = userDto.Password;
            }
            return View(userView);
        }

        //Create:
        //POST:
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserViewModel userView)
        {
            if (userView.UserViewId == 0)
            {
                User userEntity = new User
                {
                    Name = userView.Name,
                    LastName = userView.LastName,
                    Login = userView.Email,
                    Password = userView.Password,
                };
                _userService.Create(userEntity);
                _userService.Save();
                if (userEntity.Id > 0)
                {

                    return RedirectToAction("Index");
                }
            }
            
            return View();
        }




        //// GET: Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// GET: Users/Create
        ////public ActionResult Create()
        ////{
        ////    return View();
        ////}
        ////
        ////// POST: Users/Create
        ////// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ////// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Create([Bind(Include = "UserId,Name,LastName,Login,Password")] User user)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        db.Users.Add(user);
        ////        db.SaveChanges();
        ////        return RedirectToAction("Index");
        ////    }
        ////
        ////    return View(user);
        ////}

        //// GET: Users/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserId,Name,LastName,Login,Password")] UserViewModel userView)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = UserMapping.ToUser(userView);  // implicit
        //        // conversion from RegisterViewModel to User Model

        //        User uv = result; // see implicit conversion

        //        db.Users.Add(uv);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //        //db.Entry(user).State = EntityState.Modified;
        //        //db.SaveChanges();
        //        //return RedirectToAction("Index");
        //    }
        //    return View(userView);
        //}

        //// GET: Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
