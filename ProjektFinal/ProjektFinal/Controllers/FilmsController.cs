using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NlogInterface;
using ProjektFinal.DTOs;
using ProjektFinal.Models;
using ProjektFinal.Repository;

namespace ProjektFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private IRepositoryWrapper _wrapper;
        private readonly FilmContext _context;
        private readonly IMapper mapper;
        private readonly ILoggerManager _logger;
        public FilmsController(FilmContext context, IMapper mapper, ILoggerManager logger, IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
            _context = context;
            this.mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Vraća listu filmova
        /// </summary>
        /// <returns>Lista filmova</returns>
        /// <remarks>
        /// Sample request
        /// GET/api/FilmDetails
        /// </remarks>


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilmDetails()
        {

            try
            {
                var films = await _context.Films.ToListAsync();
                var filmsDto = mapper.Map<IEnumerable<Film>, IEnumerable<FilmDto>>(films);

                return Ok(filmsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Nesto je poslo po zlu u HttpGet(Film) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");

            }
        }
        
        /// <summary>
        /// Vraća films odredenim ID-om
        /// </summary>
        /// <returns>Oredeni film</returns>
        /// <remarks>
        /// Sample request
        /// GET/api/FilmDetails/2
        /// </remarks>

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDto>> GetFilmById(int id)
        {


            try
            {

                var film = await _context.Films.FindAsync(id);
                var filmDto = mapper.Map<Film, FilmDto>(film);
                if (filmDto == null)
                {
                    _logger.LogError($"Film sa unesenim ID-m nije pronadjen {id}");
                    return NotFound("Film sa unesenim ID-om nije pronaden");
                }

                return filmDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Nesto je poslo po zlu u HttpGetByID(Film) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }
        }
        /// <summary>
        /// Updejta određeni film u bazu podataka
        /// </summary>
        /// <returns>Updejtan film</returns>
        /// <remarks>
        /// Sample request
        /// PUT/api/FilmDetail
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmDetail(int id, FilmDto filmDto)
        {
            var film = mapper.Map<FilmDto, Film>(filmDto);
            if (id != film.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

            /// <summary>
            /// Uploada određeni film u bazu podataka
            /// </summary>
            /// <returns>Uploadan film</returns>
            /// <remarks>
            /// Sample request
            /// POST/api/FilmDetail
            /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilmDetail(FilmDto filmDetailDto)
        {
            
            try
            {

                var film= mapper.Map<FilmDto, Film>(filmDetailDto);
                _context.Films.Add(film);
                await _context.SaveChangesAsync();
                
                return CreatedAtAction("GetFilmDetail", new { id = film.FilmId },film);
            
            }
            catch (Exception ex)
            {

                _logger.LogError($"Nesto je poslo po zlu u HttpPost(Film) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }

        }

        /// <summary>
        /// Izbrisati film s određenim ID-om
        /// </summary>
        /// <returns>Izbrisan film</returns>
        /// <remarks>
        /// Sample request
        /// DELETE/api/FilmDetails/2
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmDetail(int id)
        {
           
            
            try
            {
                var film = await _context.Films.FindAsync(id);
                if (film == null)
                {
                    _logger.LogError($"Film sa unesenim ID-m nije pronadjen {id}");
                    return NotFound();
                }

                _context.Films.Remove(film);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Nesto je poslo po zlu u HttpDelete(Film) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }

        }
        




    }

}
