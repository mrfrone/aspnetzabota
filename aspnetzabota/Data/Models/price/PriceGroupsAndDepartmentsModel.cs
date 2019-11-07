using System.Collections.Generic;

namespace aspnetzabota.Data.Models
{
    public class PriceGroupsAndDepartmentsModel
    {
        public int grcode { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<string> DepartName { get; set; }
    }
}
