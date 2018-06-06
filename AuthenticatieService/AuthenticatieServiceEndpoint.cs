using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fabric;
using System.Threading.Tasks;
using AuthenticatieService.Interfaces;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace AuthenticatieService
{
    public sealed class AuthenticatieServiceEndpoint : StatelessService, IAuthenticatieService
    {
        private readonly ITokenValidator _validator;

        public AuthenticatieServiceEndpoint(StatelessServiceContext context, ITokenValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public Task<bool> IsTokenValid(string authenticationHeader)
        {
            if (!String.IsNullOrEmpty(authenticationHeader))
            {
                return Task.FromResult(_validator.ValidateToken(authenticationHeader));
            }
            
           return Task.FromResult(false); 
        }

        [ExcludeFromCodeCoverage]
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
        }
    }
}
