using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;

//Needed for RemotingV2
[assembly: FabricTransportServiceRemotingProvider(RemotingListener = RemotingListener.V2Listener, RemotingClient = RemotingClient.V2Client)]

namespace VPIService.Interfaces
{
    public interface IVPIService : IService
    {
        Task<String> BerekenPremie();
    }
}
