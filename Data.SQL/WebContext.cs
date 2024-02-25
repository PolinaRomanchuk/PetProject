using Data.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.SQL
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public WebContext() { }

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=.;Initial Catalog=PetProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
