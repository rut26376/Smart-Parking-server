using BL.Models;
using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLCreditCard
    {
        void Create(BlCreditCards card);
        
        List<BlCreditCards> GetCards();
        List<BlCreditCards> GetCardsForDriver(string DriverCode);



    }
}
