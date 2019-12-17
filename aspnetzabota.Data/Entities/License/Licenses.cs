using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetzabota.Content.Database.Entities
{
    public class Licenses
    {
        public int? id { get; set; }
        public string name { get; set; }
        public IEnumerable<LicensesPhoto> photo { get; set; }
    }
}
