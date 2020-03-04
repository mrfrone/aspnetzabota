using aspnetzabota.Common.Result;
using aspnetzabota.Content.Datamodel.License;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Licenses
{
    public interface ILicenses
    {
        Task<IEnumerable<ZabotaLicenses>> GetLicenses();
        Task<ZabotaResult> AddLicense(ZabotaLicenses license);
        Task<ZabotaResult> AddPhoto(ZabotaLicensesPhoto photo);
        Task<ZabotaResult> DeleteLicense(int id);
        Task<ZabotaResult> DeletePhoto(int id);

    }
}
