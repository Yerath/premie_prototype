using System;
using System.Diagnostics;
using System.Threading;
using Autofac;
using Microsoft.ServiceFabric.Services.Runtime;
using VPIService.Agents;
using VPIService.Controllers;
using VPIService.Interfaces;

namespace VPIService
{
    internal static class Program
    {
        private static IContainer Container { get; set; }

        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<VPIAgent>().As<IVPIAgent>();
                builder.RegisterType<VPIController>().As<IVPIController>();
                Container = builder.Build();

                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                ServiceRuntime.RegisterServiceAsync("VPIServiceType",
                    context => new VPIServiceEndpoint(context, Container.Resolve<IVPIController>())).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(VPIServiceEndpoint).Name);

                // Prevents this host process from terminating so services keep running.
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
