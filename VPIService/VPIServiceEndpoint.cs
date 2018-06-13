using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fabric;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using VPIService.Interfaces;

namespace VPIService
{
    public sealed class VPIServiceEndpoint : StatelessService, IVPIService
    {
        private readonly IVPIController _controller;

        public VPIServiceEndpoint(StatelessServiceContext context, IVPIController controller)
            : base(context)
        {
            _controller = controller;
        }

        public Task<String> BerekenPremie()
        {
            return Task.FromResult(_controller.GeefToken());
        }

        [ExcludeFromCodeCoverage]
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
        }
    }
}
