using System;
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
            try
            {
                return _agent.RetrieveToken(username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
