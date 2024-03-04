using System.Text.Json.Serialization;

namespace MoviesApi.Contracts.Dtos
{
    public class MovieDto
    {
        [JsonPropertyName("pk")]
        public string pk => Id.ToString();

        [JsonPropertyName("sk")]
        public string sk => Id.ToString();
        public Guid Id { get; init; } = default!;
        public required string Title { get; init; } = default!;
        public required string Genre { get; init; } = default!;
        public required string Description { get; init; } = default!;
        public required double Rating { get; init; } = default!;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}