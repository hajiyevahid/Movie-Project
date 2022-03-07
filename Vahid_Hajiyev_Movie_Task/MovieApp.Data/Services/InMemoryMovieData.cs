using MovieApp.Data.Models;

namespace MovieApp.Data.Services
{
    public class InMemoryMovieData : IMovieData
    {
        List<Movie> movies;

        public InMemoryMovieData()
        {
            movies = new List<Movie>()
            {
                new Movie { Id = 1, ReleaseYear = "2006", Title = "Very Real Movie", Genre = Genre.Comedy },
                new Movie { Id = 2, ReleaseYear = "2020", Title = "Very Real Movie 2", Genre = Genre.Tragedy },
                new Movie { Id = 3, LongDescription = "Just your typical romance.", Title = "Something, something Love", Genre = Genre.Romance },
                new Movie { Id = 4, Title = ".gitignore: The Movie", Genre = Genre.Horror }
            };
        }

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public IEnumerable<Movie> GetAll()
        {
            return movies.OrderBy(m => m.Title);
        }

        public Movie GetMovieById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public void UpdateMovie(Movie movie)
        {
            var existing = GetMovieById(movie.Id);
            if (existing != null)
            {
                existing.ReleaseYear = movie.ReleaseYear;
                existing.Title = movie.Title;
                existing.Genre = movie.Genre;
                existing.LongDescription = movie.LongDescription;
            }
        }
    }
}
