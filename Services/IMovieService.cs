using MoviesApi.Models;

namespace MoviesApi.Services
{
    public interface IMovieService
    {
        Task<bool> CreateMovieAsync(Movie movie);

        Task<Movie> GetMovieByIdAsync(Guid id);

        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<bool> UpdateMovieAsync(Movie movie);

        Task<bool> DeleteMovieAsync(Guid id);
    }
}