using System;
using System.Collections.Generic;
using System.Text;

namespace LicentieService.Interfaces
{
    public interface ILicentieController
    {
        string Login(string username, string password);
    }
}
