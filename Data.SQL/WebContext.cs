using Data.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.SQL
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> Profiles { get; set; }

        public DbSet<Post> Posts { get; set; }

        public WebContext() { }

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasOne(x => x.Profile)
               .WithOne(x => x.UserData)
               .HasForeignKey<UserProfile>(x => x.Id);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.Author)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=PetProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
