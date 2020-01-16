using System.Collections.Generic;

namespace aspnetzabota.Content.Datamodel.License
{
    public class ZabotaLicenses
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ZabotaLicensesPhoto> Photo { get; set; }
    }
}
