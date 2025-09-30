using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

public class DalVehicleService : IDalVehicles
{
    dbcontext dbcontext;

    public DalVehicleService(dbcontext data)=> dbcontext = data;
    
    public Vehicle Create(Vehicle v)
    {
       var v2 =  dbcontext.Vehicles.Add(v);
        dbcontext.SaveChanges();
        return v2.Entity;
    }

    public List<Vehicle> GetAll()=>dbcontext.Vehicles.ToList();
    
}
