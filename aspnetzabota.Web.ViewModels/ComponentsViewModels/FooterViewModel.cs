using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Web.ViewModels
{
    public class FooterViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}
