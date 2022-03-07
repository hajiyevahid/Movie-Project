using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp.Interfaces
{
    public interface IMGService
    {
        List<Genre> GetAllGenres();
        CustomMovie GetMovieById(int id);
        Genre GetGenreById(int id);

        Genre GetGenreByName(string name);

        Genre AddGenre(Genre gen);

        Genre DeleteGenre(int id);

        Genre EditGenre(Genre gen);
        List<Movie> GetAllMovies();

        Movie GetMovie(int id);

        Movie GetMovieByName(string name);

        Movie AddMovie(Movie movie);

        Movie DeleteMovie(int id);

        Movie EditMovie(Movie movie);

    }
}