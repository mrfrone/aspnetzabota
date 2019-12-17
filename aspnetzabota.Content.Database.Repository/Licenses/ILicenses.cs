using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Repository.Licenses
{
    public interface ILicenses
    {
        IEnumerable<Entities.Licenses> Take { get; }
    }
}
