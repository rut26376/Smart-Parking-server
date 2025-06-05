using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

public class DalPaymentService : IDalPayment
{
    dbcontext dbcontext;


    //c-tor
    public DalPaymentService(dbcontext data) => dbcontext = data;

    public int Create(Payment p)
    {
        var additional = dbcontext.Payments.Add(p);

        dbcontext.SaveChanges();
        return additional.Entity.Code;
    }

    public async Task<List<Payment>> GetPayments() => await dbcontext.Payments.Include(p => p.PaymentsDetails).ToListAsync();

}
