using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlCreditCardService : IBLCreditCard
    {
        IDal dal;

        //c-tor
        public BlCreditCardService(IDal dal) => this.dal = dal;
       

        public void Create(BlCreditCards card)
        {
            dal.CreditCard.Create(new CreditCard() { CreditCardNum = card.CreditCardNum, ValidityCard = card.ValidityCard, Cvv = card.Cvv, Id = card.Id, DriverCode = card.DriverCode});

        }

        public List<BlCreditCards> GetCards()
        {
            var cList = dal.CreditCard.GetAll();
            List<BlCreditCards> list = new();
            cList.ForEach(p => list.Add(new BlCreditCards()
            {
                Code = p.Code,
                CreditCardNum = p.CreditCardNum,
                ValidityCard = p.ValidityCard,
                Cvv = p.Cvv,
                DriverCode = p.DriverCode,
                Id = p.Id
            })) ;
            return list;
        }

        public List<BlCreditCards> GetCardsForDriver(string DriverCode) => GetCards().FindAll(c => c.DriverCode == DriverCode);
    
    }
}
