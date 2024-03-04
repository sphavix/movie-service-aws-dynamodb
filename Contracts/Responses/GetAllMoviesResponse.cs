namespace MoviesApi.Contracts.Responses
{
    public class GetAllMoviesResponse
    {
        public IEnumerable<MovieResponse> Movies { get; init; } = Enumerable.Empty<MovieResponse>();
    }
}
