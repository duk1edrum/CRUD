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

        public static UserDto ToUserDto(this UserViewModel userView)
        {
            return new UserDto()
            {
                Id = userView.Id,
                Name = userView.Name,
                LastName = userView.LastName,
                Password = userView.Password,
                Login = userView.Email,
            };
        }
        
    }
}