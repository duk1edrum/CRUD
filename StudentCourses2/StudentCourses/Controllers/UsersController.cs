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
        // Detail : Users
        public ActionResult Details(int? id)
        {

            UserDto userDtos = _userService.GetUser(id);
            var userView = UserViewMapping.ToUserView(userDtos);

            return View(userView);
        }

       
        // GET: Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            UserViewModel userView = new UserViewModel();
            if (id.HasValue && id != 0)
            {
                UserDto userDto = _userService.GetUser(id.Value);
                UserViewMapping.ToUserDTO(userView);
                RedirectToAction("Index");
            }
            return View(userView);
        }

        
        //POST: Create
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                var userEntity = UserViewMapping.ToUserDTO(userView);
                _userService.Create(userEntity);
              
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Users/Edit
        public ActionResult Edit(int? id)
        {
            UserViewModel userView = UserViewMapping.ToUserView(_userService.GetUser(id));

            return View(userView);
        }

        // POST: Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userView)
        {
            //!!!! Валидация должна проверять View Model. Все операции потом!!!

            if (ModelState.IsValid)
            {
                //Была полная каша в наименованиях переменных. 
                // Здесь всё просто. Модель валидна - замапили в дто и отдали сервису на обновление.
                var dto = userView.ToUserDTO();
                _userService.Update(dto);
                return RedirectToAction("Index");
            }

            return View(userView);
        }

        // GET: Users/Delete
        public ActionResult Delete(int? id)
        {
            var dto = _userService.GetUser(id);
            var view = UserViewMapping.ToUserView(dto); ;

            return View(view);
        }

        // POST: Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           _userService.Delete(id);
            
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
