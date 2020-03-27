using aspnetzabota.Content.Datamodel.License;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Licenses
{
    public interface ILicenses
    {
        Task<IEnumerable<ZabotaLicenses>> GetLicenses();
        Task<bool> AddLicense(ZabotaLicenses license);
        Task<bool> AddPhoto(ZabotaLicensesPhoto photo);
        Task<bool> DeleteLicense(int id);
        Task<bool> DeletePhoto(int id);

    }
}
