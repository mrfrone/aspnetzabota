using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.License;

namespace aspnetzabota.Web.ViewModels
{
    public class LicensesViewModel
    {
        public IEnumerable<ZabotaLicenses> Licenses { get; set; }
    }
}
