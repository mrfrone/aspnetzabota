using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.ViewModels
{
    public class FooterViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}
