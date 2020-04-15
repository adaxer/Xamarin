using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLibrary.Core.Services
{
    public class UserService : IUserService
    {
        public string UserName => "John Doe";

        public bool IsLoggedIn => true;
    }
}
