﻿using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<Department> Take { get; }
    }
}
