using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using RollsService.Entities;
using RollsService.Interfaces;

namespace RollsService
{
    public sealed class RollsServiceEndpoint : StatelessService, IRollsService
    {
        private readonly IRollsController _controller;

        public RollsServiceEndpoint(StatelessServiceContext context, IRollsController controller)
            : base(context)
        {
            _controller = controller;
        }

        public Task<PersonenautoWAMiniCasco> BerekenPremiePersonenAutoWAMiniCasco(string bsn, DateTime verjaardag, string kenteken)
        {
            return Task.FromResult(_controller.BerekenPremiePersonenAutoWAMiniCasco(bsn, verjaardag, kenteken)); 
        }

        [ExcludeFromCodeCoverage]
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
        }
    }
}
