using aspnetzabota.Data.Models;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface IReview
    {
        IEnumerable<Review> Take { get; }
    }
}
