using System.Collections.Generic;

namespace aspnetzabota.Content.Datamodel.Price
{
    public class ZabotaPriceGroupsAndDepartments
    {
        public int grcode { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<string> DepartName { get; set; }
    }
}
