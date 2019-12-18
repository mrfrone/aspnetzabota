using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Web.ViewModels
{
    public class LicensesViewModel
    {
        public IEnumerable<Licenses> Licenses { get; set; }
    }
}
