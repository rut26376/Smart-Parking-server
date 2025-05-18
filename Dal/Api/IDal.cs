using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api;

public interface IDal
{
    public IDalDriver Drivers { get; }
    public IDalParking Parkings { get; }
    public IDalPayment Payments { get; }
    public IDalRoutine Routines { get; }
    public IDalPaymentsDetails Details { get; }
    public IDalCreditCards CreditCard { get; }
    public IDalVehicles Vehicle { get; }
    public IDalCPManager Manager { get; }



}
