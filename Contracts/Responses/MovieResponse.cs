namespace MoviesApi.Contracts.Responses
{
    public class MovieResponse
    {
        public Guid Id { get; init; }
        public required string Title { get; init; } = default!;
        public required string Genre { get; init; } = default!;
        public required string Description { get; init; } = default!;
        public required double Rating { get; init; } = default!;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
