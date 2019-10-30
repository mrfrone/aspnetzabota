using System.Collections.Generic;

namespace aspnetzabota.Data.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string categoryName{ get; set; }
        public List<News> news { get; set; }
    }
}
