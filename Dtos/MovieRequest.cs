namespace MoviesApi.Dtos
{
    public class MovieRequest
    {
        public Guid Id { get; set; }
        public required string Title { get; init; }
        public required string Genre {get; init;}
        public required string Description { get; init; }
        public required double Rating { get; init; } 

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}