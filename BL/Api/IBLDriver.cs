using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBLDriver
{
   BlVehicle Get(string userName, string password,string licensePlate);
    string Create(BlDriver d,string licensePlate);
}
