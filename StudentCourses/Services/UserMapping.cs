using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using StudentCourses.ViewModels;

namespace Services
{
   public static class UserMapping
        {
            public static UserViewModel ToUserViewModel(this User user)
            {
                return new UserViewModel()
                {
                    UserViewId = user.UserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    Password = user.Password,
                    ConfirmPassword = user.Password,
                    Email = user.Login,
                };
            }

            public static User ToUser(this UserViewModel userView)
            {
                return new User()
                {
                    UserId = userView.UserViewId,
                    Name = userView.Name,
                    LastName = userView.LastName,
                    Password = userView.Password,
                    Login = userView.Email,
                };
            }
        }
    }

