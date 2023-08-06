using FilmApi.Models;
using FilmApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpPost("favorites")]
        public IActionResult AddOrRemoveFavorite(int userId, int movieId, bool addToFavorites)
        {
            _movieService.AddOrRemoveFavorite(userId, movieId, addToFavorites);
            return Ok();
        }

        [HttpPost("watched")]
        public IActionResult MarkMovieAsWatched(int userId, int movieId)
        {
            _movieService.MarkMovieAsWatched(userId, movieId);
            return Ok();
        }

        [HttpGet("favorites")]
        public IActionResult GetFavoriteMovies(int userId, string sortBy)
        {
            var favoriteMovies = _movieService.GetFavoriteMovies(userId, sortBy);
            return Ok(favoriteMovies);
        }

    }

}
