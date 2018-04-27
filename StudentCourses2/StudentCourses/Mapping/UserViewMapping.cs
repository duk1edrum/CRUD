using Service.DTO;
using StudentCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourses.Mapping
{
    public static class UserViewMapping
    {
        public static UserViewModel ToUserView(this UserDto userDto)
        {
            return new UserViewModel()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                LastName = userDto.LastName,
                Password = userDto.Password,
                Email = userDto.Login,
            };
        }

        public static void ToUserDto(this UserViewModel userView,UserDto userDto)
        {
           
            {
                userDto.Id = userView.Id;
                userDto.Name = userView.Name;
                userDto.LastName = userView.LastName;
                userDto.Password = userView.Password;
                userDto.Login = userView.Email;
            };
        }
        public static UserDto ToUserDTO(this UserViewModel userView)
        {
            var ent = new UserDto();
            userView.ToUserDto(ent);
            return ent;
        }

    }
}