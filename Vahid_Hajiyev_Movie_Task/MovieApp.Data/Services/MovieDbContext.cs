using MovieApp.Data.Models;
using System.Data.Entity;

namespace MovieApp.Data.Services
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
    }
}
