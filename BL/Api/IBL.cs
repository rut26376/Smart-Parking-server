using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBL
{
    public IBLParking Parking { get; }

    public IBLDriver Driver { get; }

    public IBLRoutine Routine { get; }

    public IBLPayment Payment { get; }
    public IBLCreditCard CreditCard { get; }
    public IBLVehicle Vehicle { get; }

    public IBLCPManager CPManager { get; }
}
