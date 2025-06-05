using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBLDriver
{
   Task<BlDriver> Get(string userName, string password);
   Task<List<BlDriver>> GetAllDrivers();
    string Create(BlDriver d);
}
