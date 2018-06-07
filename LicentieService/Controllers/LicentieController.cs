using System;
using System.Collections.Generic;
using System.Text;
using LicentieService.Exceptions;
using LicentieService.Interfaces;

namespace LicentieService.Controllers
{
    internal class LicentieController : ILicentieController
    {
        private readonly ILicentieAgent _agent;

        public LicentieController(ILicentieAgent agent)
        {
            _agent = agent;
        }

        public string Login(string username, string password)
        {
            if (!_agent.IsKnownUser(username, password))
            {
                throw new InvalidUserException("Username / Password not found in database");
            }

            return _agent.GenerateToken();   
        }
    }
}
