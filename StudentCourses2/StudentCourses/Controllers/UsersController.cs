using System.Collections.Generic;
using System.Data;
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

        public UsersController()
        {
            _userService = new UserService();
        }

        // GET: Users
        public ActionResult Index()
        {
            IEnumerable<UserDto> userDtos = _userService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDto, UserViewModel>()).CreateMapper();
            var userView = mapper.Map<IEnumerable<UserDto>, IEnumerable<UserViewModel>>(userDtos);

            return View(userView);
        }

        public ActionResult Details(int? id)
        {

            UserDto userDtos = _userService.GetUser(id);
            var userView = UserViewMapping.ToUserView(userDtos);

            return View(userView);
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
                UserViewMapping.ToUserDto(userView);
                RedirectToAction("Index");
            }
            return View(userView);
        }

        //Create:
        //POST:
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                var userEntity = UserViewMapping.ToUserDto(userView);
                _userService.Create(userEntity);
                _userService.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            ///UserDto userDto = _userService.GetUser(id);
            UserViewModel userView = UserViewMapping.ToUserView(_userService.GetUser(id));

            return View(userView);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Login,Password,ConfirmPassword")] UserViewModel userView)
        {



            //var userEntity = _userService.GetUser(userView.Id);
            //_userService.Delete(userEntity.Id);
            //_userService.Create(userEntity);
            //_userService.Create(UserViewMapping.ToUserDto(user));
            //
            UserDto user = _userService.GetUser(userView.Id);
            if (userView.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (TryUpdateModel(user))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _userService.Update(user);
                        _userService.Save();
                        return RedirectToAction("Index");
                    }
                }
                catch (DataException /**/)
                {
                    ModelState.AddModelError("", "Enable to save Changes!");
                }
            }
            ////_userService.Create(user);
            //_userService.Update(user);
            //_userService.Save();
            //return RedirectToAction("Index");

            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewMapping.ToUserView(_userService.GetUser(id));
            _userService.Delete(id);

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

        protected override void Dispose(bool disposing)
        {
            //EFUnitOfWork eFUnitOf = new EFUnitOfWork();

            //eFUnitOf.Dispose();
            //eFUnitOf.Dispose(disposing);
            //UserService.Dispose();
            //base.Dispose(disposing);
        }
    }

}
