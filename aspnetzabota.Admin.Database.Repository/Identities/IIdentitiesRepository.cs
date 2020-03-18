using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Common.Result;
using System.Threading.Tasks;

namespace aspnetzabota.Admin.Database.Repository.Identities
{
    public interface IIdentitiesRepository
    {
        Task<Entities.Identities[]> Get();
        Task<Entities.Identities> IdentityByTokenId(int id);
        Task<Entities.Identities> IdentityByLogin(string login);
        Task<Entities.Identities> GetByLoginAndPassword(LoginForm form);
        Task<bool> IdentityExistsAsync(int identityId);
        Task Add(LoginForm form);
        Task<ZabotaResult> Delete(int identityId, int actorId);
    }
}
