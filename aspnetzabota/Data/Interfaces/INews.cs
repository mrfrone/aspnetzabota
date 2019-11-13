using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Interfaces
{
    public interface INews
    {
        IEnumerable<News> Take { get; }
    }
}
