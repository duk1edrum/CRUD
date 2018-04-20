using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Service.DTO;

namespace Service.Interfaces
{
    public interface IUserService
    {
        //void ShowUsder(UserDto userDto);
        UserDto GetUser(int? id);
        IEnumerable<UserDto> GetUsers();
        void Update(UserDto userDto);
        void Create(UserDto userDto);
        void Delete(int? id);
        void Save();
        //void Dispose();
       
    }
}
