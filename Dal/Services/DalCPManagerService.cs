using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

public class DalCPManagerService : IDalCPManager
{
    dbcontext dbcontext;

    public DalCPManagerService(dbcontext data)
    {
        this.dbcontext = data;
    }

    public void Create(Manager managerPass)
    {
        dbcontext.Managers.Add(managerPass);
        dbcontext.SaveChanges();
    }

    public List<Manager> GetManagersPasswords() => dbcontext.Managers.ToList();
}
