using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api;

public interface IDalDriver
{ 
    public Task<List<Driver>> GetDrivers();
    public Task<List<Driver>> GetAll();
    public void Create(Driver d);
  
}
