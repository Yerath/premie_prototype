using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace AuthenticatieService.Interfaces
{
    public interface IAuthenticatieService : IService
    {
        Task<bool> IsTokenValid(string authHeader);

    }
}
