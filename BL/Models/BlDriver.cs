using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public class BlDriver
{
    public string? Name { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public List<BlVehicle> Vehicles { get; set; } = new List<BlVehicle>();
}
