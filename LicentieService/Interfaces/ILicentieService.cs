using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace LicentieService.Interfaces
{
    public interface ILicentieService : IService
    {
        Task<string> Login(string username, string password);
    }
}
