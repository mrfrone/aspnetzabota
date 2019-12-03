using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Mapping
{
    public static class GenericMapping<T>
    {
        private static readonly Random random = new Random();
        public static IEnumerable<T> Last(IEnumerable<T> Model, int num) => Model.TakeLast(num);
        public static IEnumerable<T> Random(IEnumerable<T> Model, int Count) => Model.OrderBy(x => random.Next()).TakeLast(Count);
    }
}
