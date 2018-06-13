using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Autofac;
using Microsoft.ServiceFabric.Services.Runtime;
using VPIService.Agents;
using VPIService.Controllers;
using VPIService.Interfaces;

namespace VPIService
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static IContainer Container { get; set; }

        private static void Main()
        {
            try
            {
                //Dependency Injection
                var builder = new ContainerBuilder();
                builder.RegisterType<VPIAgent>().As<IVPIAgent>();
                builder.RegisterType<VPIController>().As<IVPIController>();
                Container = builder.Build();

                ServiceRuntime.RegisterServiceAsync("VPIServiceType",
                    context => new VPIServiceEndpoint(context, Container.Resolve<IVPIController>())).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(VPIServiceEndpoint).Name);

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
