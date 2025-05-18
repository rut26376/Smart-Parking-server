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

public class BlDriverService : IBLDriver
{
    IDal dal;

    //c-tor
    public BlDriverService(IDal dal) => this.dal = dal;


    public BlVehicle? Get(string userName, string password, string licensePlate)
    {

        var d = dal.Drivers.GetDrivers().Find(d => d.UserName == userName && d.Password == password);
        if(d == null) 
            return null;
        var v  = dal.Vehicle.GetAll().Find(v => v.LicensePlate == licensePlate);
        if ( v == null)
             v=dal.Vehicle.Create(new Vehicle() { LicensePlate = licensePlate, DriverCode = d.Code });
        return new BlVehicle() { LicensePlate  =v.LicensePlate,DriverCode = v.DriverCode  };
        
    }

    public string Create(BlDriver d,string licensePlate)
    {
        string code = "";
        while (code == "" || dal.Drivers.GetDrivers().Exists(d => d.Code.Equals(code)))
        {
            code = randCode();
        }

        dal.Drivers.Create(new Driver() { Name = d.Name, PhoneNumber = d.PhoneNumber, UserName = d.UserName, Password = d.Password, Code = code });
        dal.Vehicle.Create(new Vehicle() { DriverCode = code, LicensePlate = licensePlate });
        return code;
    }


    private string randCode()
    {
        Random rand = new Random();
        string s = "";

        for (int i = 0; i < 5; i++)
        {
            var asky = rand.Next(48, 122);
            while (asky >= 58 && asky <= 96)
                asky = rand.Next(48, 122);
            s += (char)asky;
        }
        return s;
    }


}
