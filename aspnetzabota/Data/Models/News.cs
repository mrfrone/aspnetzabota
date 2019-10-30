using System;

namespace aspnetzabota.Data.Models
{
    public class News
    {
        public int ID { get; set; }
        public string newsName { get; set; }
        public string newsDecription { get; set; }
        public string newsIMG { get; set; }
        public DateTime newsDate { get; set; }
        public int categoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
