using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News> AllNews { get; set; }
        public string CurrentCategory { get; set; }
    }
}
