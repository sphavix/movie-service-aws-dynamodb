using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Dtos;
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
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("movies/{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if(movie is null) return NotFound();

            return Ok(movie);
        }

        [HttpPost("movies")]
        public async Task<IActionResult> Post([FromBody] MovieRequest request)
        {
            var response = await _movieService.CreateMovieAsync(request);
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, response);
        }
    }
}