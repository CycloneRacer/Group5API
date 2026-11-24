using Group5API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Group5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly Group5APIContext _context;

        // Dependency Injection supplies the shared DbContext
        public FavoriteMoviesController(Group5APIContext context)
        {
            _context = context;
        }

        // READ: GET api/FavoriteMovies, api/FavoriteMovies/0, or api/FavoriteMovies/2
        // Returns the first 5 rows if id is null or 0; otherwise returns the matching movie.
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetFavoriteMovies(int? id)
        {
            if (id == null || id == 0)
            {
                var movies = await _context.FavoriteMovie.Take(5).ToListAsync();
                return Ok(movies);
            }

            var movie = await _context.FavoriteMovie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // CREATE: POST api/FavoriteMovies
        [HttpPost]
        public async Task<ActionResult<FavoriteMovie>> PostFavoriteMovie(FavoriteMovie movie)
        {
            _context.FavoriteMovie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteMovies), new { id = movie.Id }, movie);
        }

        // UPDATE: PUT api/FavoriteMovies/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteMovie(int id, FavoriteMovie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteMovieExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: DELETE api/FavoriteMovies/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteMovie(int id)
        {
            var movie = await _context.FavoriteMovie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.FavoriteMovie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteMovieExists(int id)
        {
            return _context.FavoriteMovie.Any(e => e.Id == id);
        }
    }
}