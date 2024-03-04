using MoviesApi.Contracts.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Mappings
{
    public static class DomaintToDtoMapper
    {
        public static MovieDto ToMovieDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Rating = movie.Rating,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
