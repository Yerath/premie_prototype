using System;
using System.Threading;
using LicentieService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
            Thread.Sleep(6000);
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
            catch (Exception)
            {
                Response.StatusCode = 404;
                Response.WriteAsync("Username/Password not found");
                return BadRequest();
            }
        }
    }
}
