using MoviesApi.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public interface IMovieRepository
    {
        Task<bool> CreateMovieAsync(MovieRequest movie);

        Task<Movie> GetMovieByIdAsync(Guid id);

        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<bool> UpdateMovieAsync(MovieRequest movie);

        Task<bool> DeleteMovieAsync(Guid id);
    }
}