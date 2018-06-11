using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RollsService.Entities;

namespace RollsService.Interfaces
{
    public interface IRollsService : IService
    {
        Task<PersonenautoWAMiniCasco> BerekenPremiePersonenAutoWAMiniCasco(string bsn, DateTime verjaardag,
            string kenteken);
    }
}
