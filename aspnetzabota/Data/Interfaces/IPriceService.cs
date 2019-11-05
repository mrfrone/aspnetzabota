using aspnetzabota.Data.Models;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface IPriceService
    {
        IEnumerable<Price> All { get; }
    }
}
