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

    public BlDriverService(IDal dal)=> this.dal = dal;

    


    public async Task<BlDriver> Get(string userName, string password)
    {
        Task<List<Driver>> d = dal.Drivers.GetDrivers();
        Driver da = d.Result.Find(d => d.UserName == userName && d.Code == password);
      
        if (da == null)
            return null;
        List<BlVehicle> list = new List<BlVehicle>();
        da.Vehicles.ToList().ForEach(async v => list.Add(new BlVehicle() { DriverCode = v.DriverCode, LicensePlate = v.LicensePlate, ParkingCode = v.Routines.ToList().Find(r => r.ExitTime == null)?.ParkingCode }));
        return new BlDriver() {Code = da.Code, Vehicles = list};

    }

    public string Create(BlDriver d)
    {
        string code = "";
        while (code == "" || dal.Drivers.GetDrivers().Result.Exists(d => d.Code.Equals(code)))
        {
            code = randCode();
        }

        dal.Drivers.Create(new Driver() { Name = d.Name, PhoneNumber = d.PhoneNumber, UserName = d.UserName, Code = code });
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

    public async Task<List<BlDriver>> GetAllDrivers()
    {
        List<BlDriver> list = new List<BlDriver>();

        dal.Drivers.GetAll().Result.ForEach(p => list.Add(new BlDriver()
        {
            Name = p.Name,
            PhoneNumber = p.PhoneNumber,
            UserName = p.UserName,
            Code = p.Code

        })) ;
        return list;
    }
}
