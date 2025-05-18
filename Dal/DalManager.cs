using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

public class DalManager : IDal
{
    dbcontext data = new dbcontext();

    public IDalDriver Drivers { get; }

    public IDalParking Parkings { get; }

    public IDalPayment Payments { get; }

    public IDalRoutine Routines { get; }

    public IDalPaymentsDetails Details { get; }

    public IDalCreditCards CreditCard { get; }

    public IDalVehicles Vehicle { get; }

    public IDalCPManager Manager { get; }

    public DalManager()
    {
        Drivers = new DalDriverService(data);
        Parkings = new DalCarParkingService(data);
        Payments = new DalPaymentService(data);
        Routines = new DalRoutineService(data);
        Details = new DalPaymentDetailsService(data);
        CreditCard = new DalCreditCardService(data);
        Vehicle = new DalVehicleService(data);
        Manager = new DalCPManagerService(data);
    }
}
