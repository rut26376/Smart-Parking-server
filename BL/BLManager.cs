using BL.Api;
using BL.Services;
using Dal;
using Dal.Api;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class BLManager : IBL
{
    public IBLParking Parking { get; }

    public IBLDriver Driver { get; }

    public IBLRoutine Routine { get; }

    public IBLPayment Payment { get; }
    public IBLCreditCard CreditCard { get; }
    public IBLVehicle Vehicle { get; }
    public IBLCPManager CPManager { get; }

    public BLManager()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddSingleton<IDal, DalManager>();

        services.AddSingleton<IBLParking, BlParkingService>();
        services.AddSingleton<IBLDriver, BlDriverService>();
        services.AddSingleton<IBLRoutine, BlRoutineService>();
        services.AddSingleton<IBLPayment, BlPaymentService>();
        services.AddSingleton<IBLCreditCard, BlCreditCardService>();
        services.AddSingleton<IBLVehicle, BlVehicleService>();
        services.AddSingleton<IBLCPManager, BlCPManagerService>();


        ServiceProvider serviceProvider = services.BuildServiceProvider();

        Parking = serviceProvider.GetRequiredService<IBLParking>();

        Driver = serviceProvider.GetRequiredService<IBLDriver>();

        Routine = serviceProvider.GetRequiredService<IBLRoutine>();
     
        Payment = serviceProvider.GetRequiredService<IBLPayment>();

        CreditCard = serviceProvider.GetRequiredService<IBLCreditCard>();

        Vehicle = serviceProvider.GetRequiredService<IBLVehicle>();

        CPManager = serviceProvider.GetRequiredService<IBLCPManager>();
    }

}
