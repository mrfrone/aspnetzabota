using aspnetzabota.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnetzabota.Data.Mapping
{
    public static class PriceMapping
    {
        public static IEnumerable<PriceGroupsAndDepartmentsModel> PriceGroupsAndDepartments(IEnumerable<Price> Model) =>
        Model.GroupBy(u => new { u.grcode, u.grname })
        .Select(c =>
        new PriceGroupsAndDepartmentsModel
        {
            grcode = c.Key.grcode,
            GroupName = c.Key.grname,
            DepartName = c.Select(u => u.depart_name).Distinct()
        });
        public static IEnumerable<PriceGroupsAndDepartmentsModel> PriceDepartments(int id, IEnumerable<PriceGroupsAndDepartmentsModel> Model) => Model.Where(c => c.grcode == id);
        public static IEnumerable<Price> PriceFromGroup(int id, IEnumerable<Price> Model) => Model.Where(c => c.grcode == id);
        public static IEnumerable<Price> PriceFromDepartment(string id, IEnumerable<Price> Model) => Model.Where(c => c.depart_name == id);
        public static IEnumerable<Price> PriceFromSearch(string id, IEnumerable<Price> Model) => Model.Where(c => c.name.Contains(id, StringComparison.InvariantCultureIgnoreCase));
    }
}
