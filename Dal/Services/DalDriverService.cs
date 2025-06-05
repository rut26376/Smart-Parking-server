using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

public class DalDriverService : IDalDriver
{
    dbcontext dbcontext;

    //c-tor
    public DalDriverService(dbcontext data) => dbcontext = data;

    public async Task<List<Driver>> GetDrivers()
    {
        return await dbcontext.Drivers
            .Include(d => d.Vehicles
                .Where(v => v.Routines.Any(r => r.ExitTime == null)))
            .ThenInclude(v => v.Routines
             .Where(r => r.ExitTime == null))
            .ToListAsync();
    }


    //public async Task<List<Driver>> GetDrivers() => dbcontext.Drivers.Include(d => d.Vehicles.ToList().Find(f => f.Routines.ToList().Find(t => t.ExitTime == null) != null)).ThenInclude(v => v.Routines.ToList().Find(r => r.ExitTime == null)).ToList();

    public void Create(Driver d)
    {

        dbcontext.Drivers.Add(d);
        dbcontext.SaveChanges();
    }

    public async Task<List<Driver>>  GetAll()=>await dbcontext.Drivers.ToListAsync();
    
   

}
