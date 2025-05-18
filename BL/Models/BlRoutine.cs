using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public class BlRoutine
{
    public string LicensePlate { get; set; } = null!;

    public int ParkingCode { get; set; }

    public DateTime? Date { get; set; }

    public int? TotalPayment { get; set; }
}
