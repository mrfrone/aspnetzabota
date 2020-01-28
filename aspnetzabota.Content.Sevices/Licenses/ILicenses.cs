using aspnetzabota.Content.Datamodel.License;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Licenses
{
    public interface ILicenses
    {
        Task<IEnumerable<ZabotaLicenses>> GetLicenses();
    }
}
