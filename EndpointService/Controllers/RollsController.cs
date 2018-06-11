using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EndpointService.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RollsService.Interfaces;

namespace EndpointService.Controllers
{
    [Route("rolls")]
    public class RollsController : Controller
    {
        private readonly IRollsService _service;

        public RollsController(IRollsService service)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PersonenautoWAMiniCasco, RollsService.Entities.PersonenautoWAMiniCasco>());
            _service = service;
        }

        public IActionResult Index()
        {
            PersonenautoWAMiniCasco result = Mapper.Map<PersonenautoWAMiniCasco>(_service.BerekenPremiePersonenAutoWAMiniCasco("1232344324", DateTime.Now, "32-SKD-4L").Result);
            return Content(JsonConvert.SerializeObject(result));
        }
    }
}