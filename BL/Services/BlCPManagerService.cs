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

public class BlCPManagerService : IBLCPManager
{
    IDal dal;

    //c-tor
    public BlCPManagerService(IDal dal) => this.dal = dal;

    public void Create(string p)
    {
        dal.Manager.Create(new Manager() { ManagerPassword = p });
    }

    public List<BlCPManager> GetAll()
    {
        List<BlCPManager> list = new List<BlCPManager>();

        dal.Manager.GetManagers().ForEach(p => list.Add(new BlCPManager()
        {
            Password = p.ManagerPassword,
            UserName = p.ManagerUserName
        }));
        return list;
    }

    public bool IsManager(BlCPManager m) => dal.Manager.GetManagers().ToList().Exists(x => x.ManagerPassword == m.Password && x.ManagerUserName == m.UserName);


}
