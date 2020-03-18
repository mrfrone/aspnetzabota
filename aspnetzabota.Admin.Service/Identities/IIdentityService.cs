using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetzabota.Admin.Datamodel.Identities;
using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Common.Result;

namespace aspnetzabota.Admin.Services.Identities
{
    public interface IIdentityService
    {
        Task<IEnumerable<ZabotaIdentity>> GetIdentities();
        Task<ZabotaResult<ZabotaIdentity>> GetIdentityByTokenId(int id);
        Task<ZabotaResult> AddIdentity(LoginForm form);
        Task<ZabotaResult> DeleteIdentity(int id, int actorId);
    }
}