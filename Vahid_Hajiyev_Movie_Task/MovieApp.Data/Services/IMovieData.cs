using MovieApp.Data.Models;

namespace MovieApp.Data.Services
{
    public interface IMovieData
    {
        IEnumerable<Movie> GetAll();

        Movie GetMovieById(int id);

        void AddMovie(Movie movie);

        void UpdateMovie(Movie movie);
    }
}
