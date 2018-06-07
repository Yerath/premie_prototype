using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LicentieService.Interfaces;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace LicentieService
{
    public sealed class LicentieServiceEndpoint : StatelessService, ILicentieService
    {
        private readonly ILicentieController _controller;
        private StatelessServiceContext context;

        public LicentieServiceEndpoint(StatelessServiceContext context, ILicentieController controller)
            : base(context)
        {
            _controller = controller;
        }

        public Task<string> Login(string username, string password)
        {
            try
            {
                return Task.FromResult(_controller.Login(username, password));
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Thrown by LicentieService : " + context.InstanceId);
                throw;
            }
        }

        [ExcludeFromCodeCoverage]
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
        }
    }
}
