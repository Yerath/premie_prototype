using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AuthenticatieService.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace AuthenticatieService
{
    internal sealed class AuthenticatieService : StatelessService, IAuthenticatieService
    {
        private readonly ITokenValidator _validator;

        public AuthenticatieService(StatelessServiceContext context, ITokenValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public Task<bool> IsTokenValid(string authenticationHeader)
        {
            return Task.FromResult(_validator.ValidateToken(authenticationHeader));
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
        }
    }
}
