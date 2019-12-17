using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Interfaces
{
    public interface ILicenses
    {
        IEnumerable<Licenses> Take { get; }
    }
}
