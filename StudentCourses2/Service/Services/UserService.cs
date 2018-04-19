using System;
using System.Collections.Generic;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Service.DTO;
using Service.Infrastructure;
using Service.Interfaces;
using Service.Mapping;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private static IUnitOfWork Database { get; set; }
        

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
            //var user = UserMapping.ToUserDto0()
            if (id == null)
            {
                throw new ValidationException("User has`nt Id", "");
            }
            UserDto userDto = UserMapping.ToUserDto(Database.Users.Get(id));


            if (userDto == null)
            {
                throw new ValidationException("User not found ! ", "");
            }

            return new UserDto();
        }

        IEnumerable<UserDto> IUserService.GetUsers()
        {
            return GetUsers();
        }



        public static void Dispose()
        {
            Database.Dispose();
        }


        public void Update(UserDto userDto)
        {
            Database.Users.Update(UserMapping.ToUser(userDto));
        }

        public void Create(UserDto userDto)
        {
            Database.Users.Create(UserMapping.ToUser(userDto));
        }

        public void Save()
        {
            Database.Users.Save();
        }

        public void Delete(int? id)
        {
            Database.Users.Delete(id.Value);
        }
    }
}
