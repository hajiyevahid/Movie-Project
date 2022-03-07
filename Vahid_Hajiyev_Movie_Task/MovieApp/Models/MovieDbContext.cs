using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using System.Data.Entity.SqlServer;
using MovieApp.Services;

namespace MovieApp.Models {

    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(builder =>
            {
                // Date is a DateOnly property and date on database
                builder.Property(x => x.ReleaseDate)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public CustomMovie CustomMovies{ get; set; }
    }
}