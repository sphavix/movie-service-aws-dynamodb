using MoviesApi.Mappings;
using MoviesApi.Models;
using MoviesApi.Repositories;

namespace MoviesApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            var result = await _movieRepository.GetMovieByIdAsync(movie.Id);
            if(result is not null) throw new Exception($"Movie with {movie.Id} already exist!");

            var movieDto = movie.ToMovieDto();
            return await _movieRepository.CreateMovieAsync(movieDto);
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            var movieDto = movie.ToMovieDto();
            var result = await _movieRepository.GetMovieByIdAsync(movie.Id);
            if(result is null) throw new Exception($"Movie with {movie.Id} does not exist!");

            return await _movieRepository.UpdateMovieAsync(movieDto);
        }

        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var result = await _movieRepository.GetMovieByIdAsync(id);
            if(result is null) throw new Exception($"Movie with {id} does not exist!");

            return await _movieRepository.DeleteMovieAsync(id);
        }
    }
}