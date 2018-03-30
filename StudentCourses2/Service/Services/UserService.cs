using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Service.DTO;
using Service.Infrastructure;
using Service.Interfaces;

namespace Service.Services
{
    public class UserService:IShowUsers
    {
        private static IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public static IEnumerable<UserDto> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDto>>(Database.Users.GetAll());
        }

        void IShowUsers.Dispose()
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

        IEnumerable<UserDto> IShowUsers.GetUsers()
        {
            return GetUsers();
        }

        public static void Dispose()
        {
            Database.Dispose();
        }
    }
}
