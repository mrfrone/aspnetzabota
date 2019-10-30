using Microsoft.EntityFrameworkCore;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data
{
    public class AppDBContext : DbContext
    {
        private const string ConnectionString = "server=mysql-srv53388.hts.ru;user id=srv53388_zabota;password=49274929;database=srv53388_zabtota;persistsecurityinfo=True";

        //public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseMySQL(ConnectionString, options => 
                options.MigrationsHistoryTable("__EFMigrationsHistory")
            );

        public DbSet<News> News { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
