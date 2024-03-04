using MoviesApi.Dtos;
using MoviesApi.Models;
using System.Runtime.CompilerServices;

namespace MoviesApi.Mappings
{
    public static class MovieRequestToMovieMapper
    {
        public static MovieRequest ToMovieDto(this Movie movieRequest)
        {
            return new MovieRequest
            {
                Id = Guid.NewGuid(),
                Title = movieRequest.Title,
                Description = movieRequest.Description,
                Genre = movieRequest.Genre,
                Rating = movieRequest.Rating,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}