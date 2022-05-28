using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Csharp_WebAPI_Assignment3.Models;
using AutoMapper;
using Csharp_WebAPI_Assignment3.DTOs.MovieDTOs;
using System.Net.Mime;

namespace Csharp_WebAPI_Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        /// <summary>
        /// Gets all movies from the DB.
        /// </summary>
        /// <returns>IEnumerable of Movie DTOs (no releasedates)</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
          if (_context.Movie == null)
          {
              return NotFound();
          }
            var domainMovies = await _context.Movie.ToListAsync();

            var dtoMovies = _mapper.Map<List<MovieReadDTO>>(domainMovies);

            return dtoMovies;
        }

        // GET: api/Movies/5
        /// <summary>
        /// Gets a movie from the DB by ID.
        /// </summary>
        /// <param name="id">ID of the movie you want to get.</param>
        /// <returns>A Movie Dto object. (no releasedate)</returns>
        /// <response code="200">Successfully returns a movie dto object.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
          if (_context.Movie == null)
          {
              return NotFound();
          }
            var domainMovie = await _context.Movie.FindAsync(id);

            if (domainMovie == null)
            {
                return NotFound();
            }

            var movieReadDto = _mapper.Map<MovieReadDTO>(domainMovie);

            return movieReadDto;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a movie in the DB by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO movieDto)
        {
            var domainMovie = _mapper.Map<Movie>(movieDto);
            _context.Entry(domainMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts a movie create DTO object in the DB.
        /// </summary>
        /// <param name="movieDto"></param>
        /// <returns>Movie read DTO object.</returns>
        [HttpPost]
        public async Task<ActionResult<MovieReadDTO>> PostMovie(MovieCreateDTO movieDto)
        {
          if (_context.Movie == null)
          {
              return Problem("Entity set 'MoviesDbContext.Movie'  is null.");
          }
          var domainMovie = _mapper.Map<Movie>(movieDto);

            _context.Movie.Add(domainMovie);
            await _context.SaveChangesAsync();

            MovieReadDTO newMovieDto = _mapper.Map<MovieReadDTO>(domainMovie);

            return CreatedAtAction("GetMovie", new { id = newMovieDto.Id }, newMovieDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movie == null)
            {
                return NotFound();
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
