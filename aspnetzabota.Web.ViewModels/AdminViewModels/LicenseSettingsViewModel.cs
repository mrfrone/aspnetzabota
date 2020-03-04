using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.License;
using aspnetzabota.Content.Datamodel.Price;

namespace aspnetzabota.Web.ViewModels
{
    public class LicenseSettingsViewModel
    {
        public IEnumerable<ZabotaLicenses> Licenses { get; set; }
        public IEnumerable<ZabotaLicensesPhoto> LicensesPhoto { get; set; }

    }
}
