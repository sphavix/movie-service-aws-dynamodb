using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Contracts.Dtos;
using MoviesApi.Contracts.Requests;
using MoviesApi.Mappings;
using MoviesApi.Models;
using MoviesApi.Services;


namespace MoviesApi.Controllers
{
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet("movies")]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            var movieResponse = movies.ToMovieResponse();
            return Ok(movieResponse);
        }

        [HttpGet("movies/{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if(movie is null) return NotFound();
            
            var movieResponse = movie.ToMovieResponse();
            return Ok(movieResponse);
        }

        [HttpPost("movies")]
        public async Task<IActionResult> Create([FromBody] MovieRequest request)
        {
            var movie = request.ToMovie();
            
            await _movieService.CreateMovieAsync(movie);

            var movieResponse = movie.ToMovieResponse();

            return CreatedAtAction(nameof(Get), new { movieResponse.Id }, movieResponse);
        }

        [HttpPut("movies/{id:guid}")]
        public async Task<IActionResult> Update([FromMultiSource] UpdateCustomerRequest request)
        {
            var existingMovie = await _movieService.GetMovieByIdAsync(request.Id);

            if(existingMovie is null) return NotFound();

            var movie = request.ToMovie();
            await _movieService.UpdateMovieAsync(movie);

            var movieResponse = movie.ToMovieResponse();
            return Ok(movieResponse);
        }

        [HttpDelete("movies/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var movieDeleted = await _movieService.DeleteMovieAsync(id);

            if(!movieDeleted) return NotFound();

            return Ok();
        }
    }
}