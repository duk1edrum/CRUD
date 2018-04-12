using System;
using System.Collections.Generic;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Service.DTO;
using Service.Infrastructure;
using Service.Interfaces;

namespace Service.Services
{
    public class UserService:IUserService
    {
        private static IUnitOfWork Database { get; set; }
        private IRepository<User> _userRepository;

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public UserService()
        {
            Database = new EFUnitOfWork();
        }

        public static IEnumerable<UserDto> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDto>>(Database.Users.GetAll());
        }

        void IUserService.Dispose()
        {
            Dispose();
        }

       
        public UserDto GetUser(int? id)
        {
            if(id == null)
                throw new ValidationException("User has`nt Id","");
            var user = Database.Users.Get(id.Value);

            if(user == null)
                throw new ValidationException("User not found","");

           return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password
            };
        }

        IEnumerable<UserDto> IUserService.GetUsers()
        {
            return GetUsers();
        }
        


        public static void Dispose()
        {
            Database.Dispose();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        
        public void Create(User user)
        {
           
            _userRepository.Create(user);
            //throw new NotImplementedException();
        }

        
    }
}
