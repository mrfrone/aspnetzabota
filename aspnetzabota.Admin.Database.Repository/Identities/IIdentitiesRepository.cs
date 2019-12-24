using aspnetzabota.Admin.Forms.Login;
using System.Threading.Tasks;

namespace aspnetzabota.Admin.Database.Repository.Identities
{
    public interface IIdentitiesRepository
    {
        Task<Entities.Identities> IdentityByTokenId(int id);
        Task<Entities.Identities> GetByLoginAndPassword(LoginForm form);
        Task<bool> IdentityExistsAsync(int identityId);
    }
}
