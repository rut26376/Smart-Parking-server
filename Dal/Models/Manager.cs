using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Manager
{
    public string ManagerPassword { get; set; } = null!;

    public string ManagerUserName { get; set; } = null!;
}
