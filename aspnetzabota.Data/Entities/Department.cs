using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public int DepartmentPriceID { get; set; }
        public IEnumerable<Articles> Articles { get; set; }
    }
}
