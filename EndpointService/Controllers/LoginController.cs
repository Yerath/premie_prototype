using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LicentieService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace EndpointService.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly ILicentieService _service;

        public LoginController(ILicentieService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Content("PremiePrototype is functioning normally");
        }

        // POST login
        [HttpPost]
        public ActionResult Post(string username, string password)
        {
            try
            {
                return Content(_service.Login(username, password).Result);
            }
            catch (Exception e)
            {
                Response.StatusCode = 404;
                Response.WriteAsync("Username/Password not found");
                return BadRequest();
            }
        }
    }
}
