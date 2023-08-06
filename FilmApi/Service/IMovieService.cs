using FilmApi.Models;

namespace FilmApi.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        void AddOrRemoveFavorite(int userId, int movieId, bool addToFavorites);
        void MarkMovieAsWatched(int userId, int movieId);
        List<Movie> GetFavoriteMovies(int userId, string sortBy);
    }
}
