using MoviesApi.Contracts.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public interface IMovieRepository
    {
        Task<bool> CreateMovieAsync(MovieDto movie);

        Task<MovieDto> GetMovieByIdAsync(Guid id);

        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();

        Task<bool> UpdateMovieAsync(MovieDto movie);

        Task<bool> DeleteMovieAsync(Guid id);
    }
}