using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetzabota.Content.Database.Entities
{
    public class Category
    {
        public int ID { get; set; }
        [Column("categoryName")]
        public string Name{ get; set; }
        public List<News> news { get; set; }
    }
}
