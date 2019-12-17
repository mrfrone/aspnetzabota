using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Data
{
    public class ContentContext : DbContext
    {    
        //todo for future: put conn string in app setting and use IOptionsMonitor
        private const string ConnectionString = "server=mysql-srv53388.hts.ru;user id=srv53388_zabota;password=49274929;database=srv53388_zabtota;persistsecurityinfo=True;charset=utf8";

        //public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseMySQL(ConnectionString, options => 
                options.MigrationsHistoryTable("__EFMigrationsHistory")
            );

        public DbSet<News> News { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Licenses> Licenses { get; set; }

    }
}
