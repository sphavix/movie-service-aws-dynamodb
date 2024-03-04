using Amazon.DynamoDBv2.DataModel;

namespace MoviesApi.Models
{
    [DynamoDBTable("movies")]
    public class Movie
    {
        [DynamoDBHashKey("id")]
        public required Guid Id { get; set; } = Guid.NewGuid();

        [DynamoDBProperty("title")]
        public required string Title { get; set; }

        [DynamoDBProperty("genre")]
        public required string Genre {get; set;}
        [DynamoDBProperty("description")]
        public required string Description { get; set; }

        [DynamoDBProperty("rating")]
        public required double Rating { get; set; } 

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}