using System.Threading.Tasks;
using aspnetzabota.Admin.Datamodel.Identities;
using aspnetzabota.Common.Result;

namespace aspnetzabota.Admin.Services.Identities
{
    public interface IIdentityService
    {
        Task<ZabotaResult<ZabotaIdentity>> GetIdentityByTokenId(int id);
    }
}