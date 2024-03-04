using MoviesApi.Contracts.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Mappings
{
    public static class DtoToDomainMapper
    {
        public static Movie ToMovie(this MovieDto movieDto)
        {
            return new Movie
            {
                Id = movieDto.Id,
                Title = movieDto.Title,
                Description = movieDto.Description,
                Genre = movieDto.Genre,
                Rating = movieDto.Rating,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
