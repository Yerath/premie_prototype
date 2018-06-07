﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using LicentieService.Agents;
using LicentieService.Controllers;
using LicentieService.Interfaces;
using Microsoft.ServiceFabric.Services.Runtime;

namespace LicentieService
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                var agent = new LicentieAgent();
                var controller = new LicentieController(agent);
                ServiceRuntime.RegisterServiceAsync("LicentieServiceType",
                    context => new LicentieServiceEndpoint(context,controller)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(LicentieServiceEndpoint).Name);

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