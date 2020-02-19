using aspnetzabota.Admin.Datamodel.Identities;
using aspnetzabota.Common.Result;

namespace aspnetzabota.Web.ViewModels
{
    public class AdminMenuViewModel
    {
        public ZabotaResult<ZabotaIdentity> Identity { get; set; }
    }
}
