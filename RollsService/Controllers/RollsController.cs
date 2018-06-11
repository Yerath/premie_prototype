using System;
using System.Collections.Generic;
using System.Text;
using RollsService.Entities;
using RollsService.Interfaces;

namespace RollsService.Controllers
{
    public class RollsController : IRollsController
    {
        private readonly IRollsAgent _agent;

        public RollsController(IRollsAgent agent)
        {
            _agent = agent;
        }

        public PersonenautoWAMiniCasco BerekenPremiePersonenAutoWAMiniCasco(string bsn, DateTime verjaardag, string kenteken)
        {
            return _agent.BerekenPremiePersonenAutoWAMiniCasco(bsn, verjaardag, kenteken);
        }
    }
}
