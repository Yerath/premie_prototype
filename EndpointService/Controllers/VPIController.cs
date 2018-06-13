using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VPIService;

namespace EndpointService.Controllers
{
    [Route("vpi")]
    public class VPIController : Controller
    {
        private IVPIService _service;

        public VPIController(IVPIService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return Content(_service.BerekenPremie().Result);
        }
    }
}