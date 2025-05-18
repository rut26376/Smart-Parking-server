using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

public class DalPaymentDetailsService : IDalPaymentsDetails
{
    dbcontext dbcontext;

    //c-tor
    public DalPaymentDetailsService(dbcontext data) => dbcontext = data;

    public void Create(PaymentsDetail pd)
    {
        dbcontext.Add(pd);
        dbcontext.SaveChanges();
    }
}
