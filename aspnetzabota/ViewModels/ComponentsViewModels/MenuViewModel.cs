using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
    }
}
