using FilmApi.Controllers;
using FilmApi.Models;
using FilmApi.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FilmApi.Tests
{
    public class MoviesControllerTests
    {
        [Fact]
        public void AddOrRemoveFavorite_AddingToFavorites_ShouldReturnOkResult()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var controller = new MoviesController(movieServiceMock.Object);

            // Act
            var result = controller.AddOrRemoveFavorite(1, 1, true);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void MarkMovieAsWatched_ValidRequest_ShouldReturnOkResult()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var controller = new MoviesController(movieServiceMock.Object);

            // Act
            var result = controller.MarkMovieAsWatched(1, 1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetFavoriteMovies_ValidRequest_ShouldReturnOkResultWithMovies()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(service => service.GetFavoriteMovies(It.IsAny<int>(), It.IsAny<string>()))
                            .Returns(new List<Movie>());

            var controller = new MoviesController(movieServiceMock.Object);

            // Act
            var result = controller.GetFavoriteMovies(1, "releaseDate");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var movies = Assert.IsAssignableFrom<IEnumerable<Movie>>(okResult.Value);
            Assert.Empty(movies);
        }
    }
}
