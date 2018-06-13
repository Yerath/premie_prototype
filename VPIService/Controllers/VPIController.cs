using System;
using VPIService.Interfaces;

namespace VPIService.Controllers
{
    public class VPIController : IVPIController
    {
        private readonly IVPIAgent _agent;

        public VPIController(IVPIAgent agent)
        {
            _agent = agent;
        }

        public string GeefToken()
        {
            try
            {
                return _agent.GetToken();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
