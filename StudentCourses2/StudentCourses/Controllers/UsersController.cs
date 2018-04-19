using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
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
            //var users = UserViewMapping.ToUserView(userDtos);
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
                var userEntity = UserViewMapping.ToUserDto(userView);
                _userService.Create(userEntity);
                
                if (userEntity.Id > 0)
                {
                    
                    return RedirectToAction("Index");
                }
            }
            _userService.Save();
            
            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {


            // User user = db.Users.Find(id);

            UserDto userDtos = _userService.GetUser(id.Value);
            if (userDtos == null)
            {
                return HttpNotFound();
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

                var userEntity = UserViewMapping.ToUserDto(userView);
                _userService.Update(userEntity);
                ////var result = UserMapping.ToUser(userView);  // implicit
                //// conversion from RegisterViewModel to User Model

                //User uv = result; // see implicit conversion

                //db.Users.Add(uv);
                //db.SaveChanges();
                return RedirectToAction("Index");
                ////db.Entry(user).State = EntityState.Modified;
                ////db.SaveChanges();
                ////return RedirectToAction("Index");
            }
            return View(userView);
        }

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
