﻿using System;
using System.Collections.Generic;
using System.Text;
using Service.DTO;

namespace Service.Interfaces
{
    public interface IShowUsers
    {
        //void ShowUser(UserDto userDto);
        UserDto GetUser(int? id);
        IEnumerable<UserDto> GetUsers();
        void Dispose();
    }
}