using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetzabota.Data
{
    public class News
    {
        public int ID { get; set; }
        [Column("newsName")]
        public string Name { get; set; }
        [Column("newsDecription")]
        public string Decription { get; set; }
        [Column("newsIMG")]
        public string IMG { get; set; }
        [Column("newsDate")]
        public DateTime Date { get; set; }
        public int categoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
