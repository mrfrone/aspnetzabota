using aspnetzabota.Admin.Datamodel.Identities;
using System.Threading.Tasks;

namespace aspnetzabota.Web.Common
{
    public interface IIdentityRequestStorage
    {
        Task<ZabotaIdentity> Ensure(int tokenId);
        ZabotaIdentity Current { get; }
    }
}
