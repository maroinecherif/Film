using FilmApi.DbContexts;
using FilmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public void AddOrRemoveFavorite(int userId, int movieId, bool addToFavorites)
        {
            var userMovie = _dbContext.UserMovies.FirstOrDefault(um => um.UserId == userId && um.MovieId == movieId);

            if (userMovie == null)
            {
                userMovie = new UserMovie
                {
                    UserId = userId,
                    MovieId = movieId,
                    IsFavorite = addToFavorites,
                    HasWatched = false,
                    WatchedDate = DateTime.MinValue
                };
                _dbContext.UserMovies.Add(userMovie);
            }
            else
            {
                userMovie.IsFavorite = addToFavorites;
            }

            _dbContext.SaveChanges();
        }

        public void MarkMovieAsWatched(int userId, int movieId)
        {
            var userMovie = _dbContext.UserMovies.FirstOrDefault(um => um.UserId == userId && um.MovieId == movieId);

            if (userMovie != null)
            {
                userMovie.HasWatched = true;
                userMovie.WatchedDate = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        public List<Movie> GetFavoriteMovies(int userId, string sortBy)
        {
            IQueryable<Movie> query = _dbContext.Movies;

            var userFavorites = _dbContext.UserMovies
                .Where(um => um.UserId == userId && um.IsFavorite)
                .Select(um => um.MovieId);

            query = query.Where(movie => userFavorites.Contains(movie.Id));

            if (sortBy == "releaseDate")
            {
                query = query.OrderBy(movie => movie.ReleaseDate);
            }
            else if (sortBy == "rating")
            {
                query = query.OrderByDescending(movie => movie.Rating);
            }

            return query.ToList();
        }
    }

}
