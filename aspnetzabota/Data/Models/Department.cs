using System.Collections.Generic;

namespace aspnetzabota.Data.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public string ShortName { get; set; }
        public string IMG { get; set; }
        public string Description { get; set; }
        public int DepartmentPriceID { get; set; }
    }
}
