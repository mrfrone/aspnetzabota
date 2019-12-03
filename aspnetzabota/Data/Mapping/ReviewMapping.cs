using aspnetzabota.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace aspnetzabota.Data.Mapping
{
    public static class ReviewMapping
    {
        public static IEnumerable<Review> Reverse(IEnumerable<Review> Model) => Model.Reverse();
    }
}
