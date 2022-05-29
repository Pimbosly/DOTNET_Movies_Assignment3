using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Csharp_WebAPI_Assignment3.Models;
using System.Net.Mime;
using AutoMapper;
using Csharp_WebAPI_Assignment3.DTOs.CharacterDTOs;

namespace Csharp_WebAPI_Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CharactersController : ControllerBase
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public CharactersController(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Characters
        /// <summary>
        /// Gets all Characters from the DB.
        /// </summary>
        /// <returns>IEnumerable of Character DTOs</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
          if (_context.Character == null)
          {
              return NotFound();
          }
            var domainCharacters = await _context.Character.ToListAsync();

            var dtoCharacter = _mapper.Map<List<CharacterReadDTO>>(domainCharacters);

            return dtoCharacter;
        }

        // GET: api/Characters/5
        /// <summary>
        /// Gets a character from the DB by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Character Dto object.</returns>
        /// /// <response code="200">Successfully returns a character dto object.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
          if (_context.Character == null)
          {
              return NotFound();
          }
            var domainCharacter = await _context.Character.FindAsync(id);

            if (domainCharacter == null)
            {
                return NotFound();
            }

            var characterReadDto = _mapper.Map<CharacterReadDTO>(domainCharacter);

            return characterReadDto;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a character in the DB by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterUpdateDTO characterDto)
        {
            _context.Entry(characterDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts a character create DTO object in the DB.
        /// </summary>
        /// <param name="characterDto"></param>
        /// <returns>Character read DTO object.</returns>
        [HttpPost]
        public async Task<ActionResult<CharacterReadDTO>> PostCharacter(CharacterCreateDTO characterDto)
        {
          if (_context.Character == null)
          {
              return Problem("Entity set 'MoviesDbContext.Character'  is null.");
          }
          var domainCharacter = _mapper.Map<Character>(characterDto);

            _context.Character.Add(domainCharacter);
            await _context.SaveChangesAsync();

            CharacterReadDTO newCharacterDto = _mapper.Map<CharacterReadDTO>(domainCharacter);

            return CreatedAtAction("GetCharacter", new { id = newCharacterDto.Id }, newCharacterDto);
        }

        // DELETE: api/Characters/5
        /// <summary>
        /// Deletes a character from the DB.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Character == null)
            {
                return NotFound();
            }
            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Character.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Character?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
