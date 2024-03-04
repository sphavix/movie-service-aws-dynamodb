using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
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

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var movies = new ScanRequest
            {
                TableName = _tableName
            };

            var response = await _dynamoDb.ScanAsync(movies);

            return response.Items.Select(x =>
            {
                var json = Amazon.DynamoDBv2.DocumentModel.Document.FromAttributeMap(x).ToJson();
                return JsonSerializer.Deserialize<Movie>(json); 
            });
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            var movie = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"id", new AttributeValue { S = id.ToString()}}
                }
            };

            var response = await _dynamoDb.GetItemAsync(movie);
            if(response.Item.Count == 0) throw new Exception($"Movie with Id {id} Not Found!");
            var itemDocument = Amazon.DynamoDBv2.DocumentModel.Document.FromAttributeMap(response.Item);
            
            return JsonSerializer.Deserialize<Movie>(itemDocument.ToJson());
        }

        public async Task<bool> CreateMovieAsync(Movie request)
        {
            var movie = JsonSerializer.Serialize(request);
            var movieAttributes = Amazon.DynamoDBv2.DocumentModel.Document.FromJson(movie).ToAttributeMap();

            var createMovie = new PutItemRequest
            {
                TableName = _tableName,
                Item = movieAttributes
            };

            var response = await _dynamoDb.PutItemAsync(createMovie);

            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> UpdateMovieAsync(Movie request)
        {
            var movie = JsonSerializer.Serialize(request);
            var movieAttributes = Amazon.DynamoDBv2.DocumentModel.Document.FromJson(movie).ToAttributeMap();

            var createMovie = new PutItemRequest
            {
                TableName = _tableName,
                Item = movieAttributes
            };

            var response = await _dynamoDb.PutItemAsync(createMovie);

            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var movie = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"id", new AttributeValue { S = id.ToString()}}
                }
            };

            var response = await _dynamoDb.DeleteItemAsync(movie);

            return response.HttpStatusCode == HttpStatusCode.OK;
        }
    }
}