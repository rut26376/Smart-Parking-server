﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBLCPManager
{
    public List<string> GetAll();
    public void Create(string p);
}
