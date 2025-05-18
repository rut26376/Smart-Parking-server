using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalCreditCardService : IDalCreditCards
    {
        dbcontext dbcontext;

        //c-tor
        public DalCreditCardService(dbcontext data) => dbcontext = data;   
        
        public int Create(CreditCard cc)
        {
           var newc= dbcontext.CreditCards.Add(cc);
            dbcontext.SaveChanges();
            return newc.Entity.Code;
        }

     
        public List<CreditCard> GetAll() => dbcontext.CreditCards.ToList();
       
    }
}
