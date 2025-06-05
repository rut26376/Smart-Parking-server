using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBLPayment
{
    Task<List<BlPayment>> GetPayments();
    void Create(Shiluv shlvush, string licensePlate, int numOfPayments);
}
