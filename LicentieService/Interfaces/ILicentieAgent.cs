using System;
using System.Collections.Generic;
using System.Text;

namespace LicentieService.Interfaces
{
    internal interface ILicentieAgent
    {
        bool IsKnownUser(string username, string password);
        string GenerateToken();
    }
}
