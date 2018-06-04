using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace AuthenticatieService.Interfaces
{
    public interface IAuthenticatieService : IService
    {
        Task<bool> IsTokenValid(string authHeader);

    }
}
