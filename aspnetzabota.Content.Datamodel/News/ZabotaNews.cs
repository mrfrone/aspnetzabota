using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetzabota.Content.Datamodel.News
{
    public class ZabotaNews
    {
        public int Id { get; set; }
        [Column("newsName")]
        public string Name { get; set; }
        [Column("newsDecription")]
        public string Decription { get; set; }
        [Column("newsIMG")]
        public string IMG { get; set; }
        [Column("newsDate")]
        public DateTimeOffset Date { get; set; }
        public int CategoryID { get; set; }
        public virtual ZabotaCategory Category { get; set; }
    }
}
