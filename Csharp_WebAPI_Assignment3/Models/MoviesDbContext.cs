using Microsoft.EntityFrameworkCore;

namespace Csharp_WebAPI_Assignment3.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Franchise> Franchise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(SeedHelper.GetMovieSeeds());
            modelBuilder.Entity<Character>().HasData(SeedHelper.GetCharacterSeeds());
            modelBuilder.Entity<Franchise>().HasData(SeedHelper.GetFranchiseSeeds());
        }
    }
}
