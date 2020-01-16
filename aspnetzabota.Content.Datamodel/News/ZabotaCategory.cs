using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetzabota.Content.Datamodel.News
{
    public class ZabotaCategory
    {
        public int Id { get; set; }
        [Column("categoryName")]
        public string Name{ get; set; }
        public List<ZabotaNews> News { get; set; }
    }
}
