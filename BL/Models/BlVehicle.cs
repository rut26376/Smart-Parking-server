using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public class BlVehicle
{
    public string LicensePlate { get; set; } = null!;

    public string DriverCode { get; set; } = null!;

    public int?  ParkingCode { get; set; } = null;

}
