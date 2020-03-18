using System.Collections.Generic;
using aspnetzabota.Admin.Datamodel.Identities;

namespace aspnetzabota.Web.ViewModels
{
    public class IdentitySettingsViewModel
    {
        public IEnumerable<ZabotaIdentity> Identities { get; set; }
        public ZabotaIdentity CurrentIdentity { get; set; }

    }
}
