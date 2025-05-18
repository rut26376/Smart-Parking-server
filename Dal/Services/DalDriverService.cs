using Dal.Api;
using Dal.Models;
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

    public List<Driver> GetDrivers() => dbcontext.Drivers.ToList();

    public void Create(Driver d)
    {

        dbcontext.Drivers.Add(d);
        dbcontext.SaveChanges();
    }

}
