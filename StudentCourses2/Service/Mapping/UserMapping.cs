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

        public static User ToUser(this UserDto userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                LastName = userDto.LastName,
                Password = userDto.Password,
                Login = userDto.Login,
            };
        }
    }
}

