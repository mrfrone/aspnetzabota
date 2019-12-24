using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Content.Database.Context
{
    public class ContentContext : DbContext
    {    
        public ContentContext(DbContextOptions<ContentContext> options) : base(options) { }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Licenses> Licenses { get; set; }

    }
}
