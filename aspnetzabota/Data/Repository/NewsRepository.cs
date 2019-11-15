using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Repository
{
    public class NewsRepository : INews
    {
        private readonly AppDBContent appDBContent;

        public NewsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<News> Take => appDBContent.News;
    }
}
