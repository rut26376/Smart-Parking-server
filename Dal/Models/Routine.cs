using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Routine
{
    public int Code { get; set; }

    public string LicensePlate { get; set; } = null!;

    public int ParkingCode { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? EntryTime { get; set; }

    public TimeSpan? ExitTime { get; set; }

    public int? TotalPayment { get; set; }

    public virtual Vehicle LicensePlateNavigation { get; set; } = null!;

    public virtual CarParking ParkingCodeNavigation { get; set; } = null!;
}
