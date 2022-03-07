using Moq;
using MovieApp.Data.Models;
using MovieApp.Data.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace MovieApp.Tests
{
    public class MovieDataTests
    {
        private readonly Mock<MovieDbContext> mockDbContext;
        private readonly Mock<DbSet<Movie>> mockSet;
        private readonly MovieData sut;
        readonly List<Movie> data = new()
        {
            new Movie { Id = 1, ReleaseYear = "2006", Title = "Very Real Movie", Genre = Genre.Comedy },
            new Movie { Id = 2, ReleaseYear = "2020", Title = "Very Real Movie 2", Genre = Genre.Tragedy },
            new Movie { Id = 3, LongDescription = "Just your typical romance.", Title = "Something, something Love", Genre = Genre.Romance },
            new Movie { Id = 4, Title = ".gitignore: The Movie", Genre = Genre.Horror },
            new Movie { Id = 5, Genre = Genre.Children, ReleaseYear = "1989", Title = "A Beautiful Mind" },
            new Movie { Id = 6, Genre = Genre.Comedy, ReleaseYear = "2019", Title = "Hangover" },
            new Movie { Id = 7, Genre = Genre.Tragedy, ReleaseYear = "2001", Title = "Pianist" },
            new Movie { Id = 8, Genre = Genre.Horror, ReleaseYear = "2004", Title = "Wrong Turn" },

        };

        public MovieDataTests()
        {
            var mockData = data.AsQueryable();

            mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());
            mockDbContext = new Mock<MovieDbContext>("connectionString");
            mockDbContext.Setup(m => m.Movies).Returns(mockSet.Object);
            sut = new MovieData(mockDbContext.Object);
        }

        [Fact]
        public void AddMovi_ValidInout_AddsMovieToDb()
        {
            // Arrange
            var movie = new Movie { Id = 9, Title = "John Wick", Genre = Genre.Horror, ReleaseYear = "2017", LongDescription = "John wick is alone man who takes his revenge from enemies" };

            // Act
            sut.AddMovie(movie);

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Movie>()), Times.Once());
            mockSet.Verify(m => m.Add(movie), Times.Once());
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void GetAll_Returns_All_Movies_FromDB_orderBy_Title()
        {
            // Arrange & Act
            var result = sut.GetAll().ToList();

            // Assert
            Assert.Equal(8, result.Count);
            Assert.Equal(data[0].Title, result[5].Title);
            Assert.Equal(data[1].Title, result[6].Title);
            Assert.Equal(data[2].Title, result[4].Title);
            Assert.Equal(data[3].Title, result[0].Title);
            Assert.Equal(data[4].Title, result[1].Title);
        }


        [Fact]
        public void GetAll_Returns_All_Movies_FromDB_orderBy_Genre()
        {
            // Arrange & Act
            var result = sut.GetAll().ToList();

            // Assert
            Assert.Equal(8, result.Count);
            Assert.Equal(data[5].Genre, result[5].Genre);
            Assert.Equal(data[6].Genre, result[6].Genre);

        }

        [Fact]
        public void GetAll_Returns_All_Movies_FromDB_orderBy_ReleaseYear()
        {
            // Arrange & Act
            var result = sut.GetAll().ToList();

            // Assert
            Assert.Equal(8, result.Count);
            Assert.Equal(data[7].ReleaseYear, result[7].ReleaseYear);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void GetMovieByIdTest(int id)
        {
            // Arrange & Act
            var result = sut.GetMovieById(id);

            // Assert
            Assert.Equal(data[id - 1].Title, result.Title);
        }
    }
}