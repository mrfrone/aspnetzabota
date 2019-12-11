using aspnetzabota.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Interfaces
{
    public interface ILicenses
    {
        IEnumerable<Licenses> Take { get; }
    }
}
