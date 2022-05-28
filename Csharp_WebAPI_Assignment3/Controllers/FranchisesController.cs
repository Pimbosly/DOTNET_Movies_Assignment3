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
using Csharp_WebAPI_Assignment3.DTOs.FranchiseDTOs;

namespace Csharp_WebAPI_Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class FranchisesController : ControllerBase
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public FranchisesController(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Franchises
        /// <summary>
        /// Gets all franchises from the DB.
        /// </summary>
        /// <returns>IEnumerable of Franchise DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
          if (_context.Franchise == null)
          {
              return NotFound();
          }
            var domainFranchise = await _context.Franchise.ToListAsync();

            var dtoFranchise = _mapper.Map<List<FranchiseReadDTO>>(domainFranchise);

            return dtoFranchise;
        }

        // GET: api/Franchises/5
        /// <summary>
        /// Gets a franchise from the DB by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Franchise Dto object.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
          if (_context.Franchise == null)
          {
              return NotFound();
          }
            var domainFranchise = await _context.Franchise.FindAsync(id);

            if (domainFranchise == null)
            {
                return NotFound();
            }

            var franchiseReadDto = _mapper.Map<FranchiseReadDTO>(domainFranchise);

            return franchiseReadDto;
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a franchise in the DB by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchiseDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseUpdateDTO franchiseDto)
        {
            _context.Entry(franchiseDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts a franchise create DTO object in the DB.
        /// </summary>
        /// <param name="franchiseDto"></param>
        /// <returns>Franchise read DTO object.</returns>
        [HttpPost]
        public async Task<ActionResult<FranchiseReadDTO>> PostFranchise(FranchiseCreateDTO franchiseDto)
        {
          if (_context.Franchise == null)
          {
              return Problem("Entity set 'MoviesDbContext.Franchise'  is null.");
          }
          var domainFranchise = _mapper.Map<Franchise>(franchiseDto);

            _context.Franchise.Add(domainFranchise);
            await _context.SaveChangesAsync();

            FranchiseReadDTO newFranchiseDto = _mapper.Map<FranchiseReadDTO>(domainFranchise);

            return CreatedAtAction("GetFranchise", new { id = newFranchiseDto.Id }, newFranchiseDto);
        }

        // DELETE: api/Franchises/5
        /// <summary>
        /// Deletes a franchise from the DB.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (_context.Franchise == null)
            {
                return NotFound();
            }
            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchise.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FranchiseExists(int id)
        {
            return (_context.Franchise?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
