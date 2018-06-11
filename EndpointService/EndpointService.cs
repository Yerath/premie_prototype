using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fabric;
using System.IO;
using AuthenticatieService.Interfaces;
using LicentieService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Runtime;
using RollsService.Interfaces;

namespace EndpointService
{
    [ExcludeFromCodeCoverage]
    internal sealed class EndpointService : StatelessService
    {
        public EndpointService(StatelessServiceContext context)
            : base(context)
        { }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        return new WebHostBuilder()
                                    .UseKestrel()
                                    .ConfigureServices(
                                        services => {
                                            //TODO: Still need to add the following service with more then 80% tests
                                            //      - VPIService
                                            //      - InternePremieService
                                            //      - PremieDataService

                                            services.AddSingleton(serviceContext);
                                            services.AddScoped(
                                                service => ServiceProxy.Create<IAuthenticatieService>(new Uri("fabric:/PremiePrototype/AuthenticatieService"))
                                            );
                                            services.AddScoped(
                                                service => ServiceProxy.Create<ILicentieService>(new Uri("fabric:/PremiePrototype/LicentieService"))
                                            );
                                            services.AddScoped(
                                                service => ServiceProxy.Create<IRollsService>(new Uri("fabric:/PremiePrototype/RollsService"))
                                            );
                                        }
                                    )
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
    }
}
