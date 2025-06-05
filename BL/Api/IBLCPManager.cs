using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBLCPManager
{
    public List<BlCPManager> GetAll();
    public bool IsManager(BlCPManager m);
    public void Create(string p);
}
