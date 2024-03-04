namespace MoviesApi.Contracts.Requests
{
    public class MovieRequest
    {
        public required string Title { get; init; } = default!;
        public required string Genre { get; init; } = default!;
        public required string Description { get; init; } = default!;
        public required double Rating { get; init; } = default!;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
