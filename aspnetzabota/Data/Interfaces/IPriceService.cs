using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
     public interface IPriceService
     {
        IEnumerable<Price> Take { get; }
         IEnumerable<PriceGroupsAndDepartmentsModel> GroupsAndDepartments { get; }
         IEnumerable<PriceGroupsAndDepartmentsModel> PriceDepartments(int id);
         IEnumerable<Price> FromGroup(int id);
         IEnumerable<Price> FromDepartment(string id);
         IEnumerable<Price> FromSearch(string id);
     }
}
