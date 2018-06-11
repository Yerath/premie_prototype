using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Runtime;
using RollsService.Agents;
using RollsService.Controllers;

namespace RollsService
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var agent = new RollsAgent();
                var controller = new RollsController(agent);

               ServiceRuntime.RegisterServiceAsync("RollsServiceType",
                    context => new RollsServiceEndpoint(context, controller)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(RollsServiceEndpoint).Name);

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
