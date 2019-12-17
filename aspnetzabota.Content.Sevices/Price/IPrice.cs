using System.Collections.Generic;

namespace aspnetzabota.Content.Services.Price
{
     public interface IPrice
     {
        IEnumerable<Database.Entities.Price> Take { get; }
         IEnumerable<Database.Entities.PriceGroupsAndDepartmentsModel> GroupsAndDepartments { get; }
         IEnumerable<Database.Entities.PriceGroupsAndDepartmentsModel> PriceDepartments(int id);
         IEnumerable<Database.Entities.Price> FromGroup(int id);
         IEnumerable<Database.Entities.Price> FromDepartment(string id);
         IEnumerable<Database.Entities.Price> FromSearch(string id);
     }
}
