using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetzabota.Admin.Datamodel.Identities;
using aspnetzabota.Admin.Forms.Login;

namespace aspnetzabota.Admin.Services.Identities
{
    public interface IIdentityService
    {
        Task<IEnumerable<ZabotaIdentity>> GetIdentities();
        Task<ZabotaIdentity> GetIdentityByTokenId(int id);
        Task<bool> AddIdentity(LoginForm form);
        Task<bool> DeleteIdentity(int id, int actorId);
    }
}