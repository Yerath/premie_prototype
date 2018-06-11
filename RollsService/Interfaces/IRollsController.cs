using System;
using System.Collections.Generic;
using System.Text;
using RollsService.Entities;

namespace RollsService.Interfaces
{
    public interface IRollsController
    {
        PersonenautoWAMiniCasco BerekenPremiePersonenAutoWAMiniCasco(string bsn, DateTime verjaardag, string kenteken);
    }
}
