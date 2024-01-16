using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using placement_cell_final.Shared.Models;

namespace placement_cell_final.Server.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Add unique constraint for the Email property in the User entity
        //     modelBuilder.Entity<User>()
        //         .HasIndex(u => u.Email)
        //         .IsUnique();

        //     // Add other configurations...

        //     base.OnModelCreating(modelBuilder);
        // }

        public DbSet<PlacementApplication> PlacementApplications { get; set; }

        public DbSet<Placement> Placements { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
