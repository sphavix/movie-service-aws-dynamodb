using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MoviesApi.Contracts.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public class MovieRepository : IMovieRepository
{
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly string _tableName = "movies";

        public MovieRepository(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = new ScanRequest
            {
                TableName = _tableName
            };

            var response = await _dynamoDb.ScanAsync(movies);

            return response.Items.Select(x =>
            {
                var json = Amazon.DynamoDBv2.DocumentModel.Document.FromAttributeMap(x).ToJson();
                return JsonSerializer.Deserialize<MovieDto>(json); 
            });
        }

        public async Task<MovieDto> GetMovieByIdAsync(Guid id)
        {
            var movieRequest = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"pk", new AttributeValue { S = id.ToString()}},
                    { "sk", new AttributeValue{ S = id.ToString()}},
                }
            };

            var response = await _dynamoDb.GetItemAsync(movieRequest);
            if(response.Item.Count == 0) throw new Exception($"Movie with Id {id} Not Found!");
            var itemDocument = Amazon.DynamoDBv2.DocumentModel.Document.FromAttributeMap(response.Item);
            
            return JsonSerializer.Deserialize<MovieDto>(itemDocument.ToJson());
        }

        public async Task<bool> CreateMovieAsync(MovieDto movie)
        {
            movie.UpdatedAt = DateTime.UtcNow;

            var movieJson = JsonSerializer.Serialize(movie);
            var movieAttributes = Amazon.DynamoDBv2.DocumentModel.Document.FromJson(movieJson).ToAttributeMap();

            var createMovie = new PutItemRequest
            {
                TableName = _tableName,
                Item = movieAttributes
            };

            var response = await _dynamoDb.PutItemAsync(createMovie);

            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> UpdateMovieAsync(MovieDto movie)
        {
            movie.UpdatedAt = DateTime.UtcNow;
            var movieAsJson = JsonSerializer.Serialize(movie);
            var movieAttributes = Amazon.DynamoDBv2.DocumentModel.Document.FromJson(movieAsJson).ToAttributeMap();

            var putItemRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = movieAttributes
            };

            var response = await _dynamoDb.PutItemAsync(putItemRequest);

            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var deleteItemRequest = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"pk", new AttributeValue { S = id.ToString()}},
                    { "sk", new AttributeValue{ S = id.ToString()}},
                }
            };

            var response = await _dynamoDb.DeleteItemAsync(deleteItemRequest);

            return response.HttpStatusCode == HttpStatusCode.OK;
        }
    }
}