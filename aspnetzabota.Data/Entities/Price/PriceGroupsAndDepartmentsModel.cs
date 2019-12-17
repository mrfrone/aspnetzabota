using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Entities
{
    public class PriceGroupsAndDepartmentsModel
    {
        public int grcode { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<string> DepartName { get; set; }
    }
}
