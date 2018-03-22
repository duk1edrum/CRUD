using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;

namespace Data.Extensions
{
    public class UserMapping
    {
        public static UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel()
            {
                UserViewId  = user.UserId,
                Name = user.Name,
                LastName = user.LastName,
                Password = user.Password,
                ConfirmPassword = user.Password,
                Email = user.Login,
            };
        }

        public static User ToUser(UserViewModel userView)
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
