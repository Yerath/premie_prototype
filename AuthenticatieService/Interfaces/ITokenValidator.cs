using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticatieService.Interfaces
{
    public interface ITokenValidator
    {
        bool ValidateToken(string token);
    }
}
