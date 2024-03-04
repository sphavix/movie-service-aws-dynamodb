using MoviesApi.Contracts.Requests;
using MoviesApi.Models;

namespace MoviesApi.Mappings
{
    public static class ApiContractToDomainMapper
    {
        public static Movie ToMovie(this MovieRequest request)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Genre = request.Genre,
                Rating = request.Rating,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static Movie ToMovie(this UpdateCustomerRequest request)
        {
            return new Movie
            {
                Id = request.Id,
                Title = request.Movie.Title,
                Description = request.Movie.Description,
                Genre = request.Movie.Genre,
                Rating = request.Movie.Rating,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
