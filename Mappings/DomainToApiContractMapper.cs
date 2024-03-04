using MoviesApi.Contracts.Responses;
using MoviesApi.Models;

namespace MoviesApi.Mappings
{
    public static class DomainToApiContractMapper
    {
        public static MovieResponse ToMovieResponse(this Movie movie)
        {
            return new MovieResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Rating = movie.Rating,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static GetAllMoviesResponse ToMovieResponse(this IEnumerable<Movie> movies)
        {
            return new GetAllMoviesResponse
            {
                Movies = movies.Select(x => new MovieResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Genre = x.Genre,
                    Rating = x.Rating,
                    UpdatedAt = DateTime.UtcNow
                })
            };
        }
    }
}
