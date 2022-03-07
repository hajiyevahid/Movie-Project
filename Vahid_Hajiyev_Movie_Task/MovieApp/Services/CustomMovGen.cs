using MovieApp.Services;
using MovieApp.Interfaces;
using MovieApp.Models;
using System.Globalization;

namespace MovieApp.Services
{
    public class CustomMovGen:IMGService
    {

        private MovieDbContext _db;

        public CustomMovGen(MovieDbContext db)
        {
            _db = db;
        }

        public List<CustomMovie> GetAllMG()
        {
            var genres = (from mov in _db.Movies
                          join gen in _db.Genres on mov.GenreId equals gen.Id
                          select new CustomMovie
                          {
                              Id = mov.Id,
                              Director = mov.Director,
                              LongDescription = mov.LongDescription,
                              Title = mov.Title,
                              ReleaseDate = mov.ReleaseDate,
                              MainCast = mov.MainCast,
                              Genre = gen.GenreName,
                              GenreId = gen.Id
                          }).ToList();
            return genres;
        }

        public Genre GetGenreById(int id)
        {
            var genre = (_db.Genres.Select(m=>m).Where(m=>m.Id==id)).First();

            return genre;
        }

        public Genre GetGenreByName(string name)
        {
            var genre = (_db.Genres
            .Select(m => m)
            .Where(x => x.GenreName.Contains(name))).First();

            return genre;
        }

        public Genre DeleteGenre(int id)
        {
            var genre = GetGenreById(id);
            _db.Genres.Remove(genre);
            _db.SaveChanges();
            return genre;
        }

        public Genre AddGenre(Genre gen)
        {
            _db.Genres.Add(gen);
            _db.SaveChanges();
            return gen;
        }
        public Genre EditGenre(Genre gen)
        {
            _db.Update(gen);
            _db.SaveChanges();
            return gen;
        }
        public List<Movie> GetAllMovies()
        {
            var movies = (_db.Movies
                        .Select(m => m)
                        .OrderBy(n => n)).ToList();
            return movies;
        }
        public List<Genre> GetAllGenres()
        {
            var genres = (_db.Genres
                        .Select(m => m)
                        .OrderBy(n => n)).ToList();
            return genres;
        }
        public CustomMovie GetMovieById(int id)
        {
            var genres = (from mov in _db.Movies
                          join gen in _db.Genres on mov.GenreId equals gen.Id
                          where mov.Id == id
                          select new CustomMovie
                          {
                              Id = mov.Id,
                              Director = mov.Director,
                              LongDescription = mov.LongDescription,
                              Title = mov.Title,
                              ReleaseDate = mov.ReleaseDate,
                              MainCast = mov.MainCast,
                              Genre = gen.GenreName,
                              GenreId = gen.Id
                          }).First();
            return genres;
        }

        public Movie GetMovieByName(string name)
        {
            var movie = (_db.Movies
            .Select(m => m)
            .Where(x => x.Title.Contains(name))).First();
            return Map(movie);
        }

        public Movie DeleteMovie(int id)
        {
            var movie = GetMovie(id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return movie;
        }
        public Movie GetMovie(int id)
        {
            var movie = _db.Movies
                        .Select(m => m)
                        .Where(m=>m.Id==id).First();
            return movie;
        }

        public Movie AddMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        }
        public Movie EditMovie(Movie movie)
        {
            
            var originMov = GetMovie(movie.Id);
            originMov.Title = movie.Title;
            originMov.GenreId = movie.GenreId;
            originMov.ReleaseDate = movie.ReleaseDate;
            originMov.LongDescription = movie.LongDescription;
            originMov.Director = movie.Director;
            originMov.MainCast = movie.MainCast;
            _db.SaveChanges();
            return movie;
        }

        private static Movie Map(Movie movie)
        {

            return new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate,
                LongDescription = movie.LongDescription,
            };
        }

    }
}

//IEnumerable<Movie> GetAllMovies();

//Movie GetMovieById(int id);

//Movie GetMovieByName(string name);

//int AddMovie(Movie movie);

//int DeleteMovie(int id);

//int EditMovie(Movie movie);