using FilmApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(
               new Movie { Id = 1, Title = "Movie 1", ReleaseDate = DateTime.Now, Rating = 7.5 },
               new Movie { Id = 2, Title = "Movie 2", ReleaseDate = DateTime.Now.AddMonths(-1), Rating = 8.2 });

            modelBuilder.Entity<User>().HasData(
             new User { Id = 1, Username = "testuser",});
        }
    }
}
