using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Mapping
{
    public static class GenericMapping<T>
    {
        public static IEnumerable<T> Last(int num, IEnumerable<T> Model) => Model.TakeLast(num);
    }
}
