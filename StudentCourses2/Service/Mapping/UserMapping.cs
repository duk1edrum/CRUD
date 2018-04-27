using Data.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mapping
{
    public static class UserMapping
    {

        public static UserDto ToUserDto(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Password = user.Password,
                Login = user.Login,
            };
        }

        public static void ToUser(this UserDto userDto, User user)
        {
            user.Id = userDto.Id;
            user.Name = userDto.Name;
            user.LastName = userDto.LastName;
            user.Password = userDto.Password;
            user.Login = userDto.Login;
        }

        public static User ToUser(this UserDto userDto)
        {
            var ent = new User();
            userDto.ToUser(ent);
            return ent;
        }
    }
}

