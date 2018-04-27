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

        public IEnumerable<UserDto> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDto>>(Database.Users.GetAll());
        }
        
        public UserDto GetUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("User has`nt Id", "");
            }
            UserDto userDto = UserMapping.ToUserDto(Database.Users.Get(id));

            if (userDto == null)
            {
                throw new ValidationException("User not found ! ", "");
            }
            return userDto;
        }

        public static void Dispose()
        {
            Database.Dispose();
        }

        public void Update(UserDto userDto)
        {

            var entity = Database.Users.Get(userDto.Id);

            //Посмотри как я переделал маппер.
            //Здесь была проблема. Ты когда мапил, возвращал НОВЫЙ обьект, но 
            // dbContext уже имел у себя в списке сущность с ID = 2.
            // Когда ты пытался сохранить, у тебя была коллизия, так как ты dbContext передавал НОВЫЙ обьект
            // с таким же ID.
            userDto.ToUser(entity);

            //Убрал SaveChanges() из этого метода. Сервисы решают когда нужно сохранить БД.
            
            Database.Users.Update(entity);

            // Сохраняем конкретный репозиторий. 
            // Здесь могло бы быть ещё так:
            // Database.Courses.Add(new Course);
            // Database.Courses.Save();
            // Но это тоже не совсем правильно ))))
            Database.Users.Save();
            
        }

        public void Create(UserDto userDto)
        {
            Database.Users.Create(UserMapping.ToUser(userDto));
            Database.Students.Save();
        }


        public void Delete(int? id)
        {
            Database.Users.Delete(id.Value);
            Database.Students.Save();
        }
    }
}
