using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLibrary.Core.Interfaces
{
    public interface IUserService
    {
        string UserName { get; }
        bool IsLoggedIn { get; }
    }
}
