using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services;

public class BlVehicleService : IBLVehicle
{
    IDal dal;
    public BlVehicleService(IDal manager)=> this.dal = manager;
    

    public void Create(BlVehicle v) => dal.Vehicle.Create(new Vehicle() { DriverCode = v.DriverCode, LicensePlate = v.LicensePlate });


    public string GetDriverCode(string licensePlate) => dal.Vehicle.GetAll().Find(v => v.LicensePlate == licensePlate).DriverCode;



}
