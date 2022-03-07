using MovieApp.Data.Models;
using System.Data.Entity;

namespace MovieApp.Data.Services
{
    public class MovieData : IMovieData
    {
        private readonly MovieDbContext _db;

        public MovieData(MovieDbContext db)
        {
            _db = db;
        }

        public void AddMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return from m in _db.Movies
                   orderby m.Title
                   select m;
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movies.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateMovie(Movie movie)
        {
            var entry = _db.Entry(movie);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
