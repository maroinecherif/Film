namespace FilmApi.Models
{
    public class UserMovie
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public bool IsFavorite { get; set; }
        public bool HasWatched { get; set; }
        public DateTime WatchedDate { get; set; }
    }
}
