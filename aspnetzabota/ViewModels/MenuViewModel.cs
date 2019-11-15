using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
    }
}
