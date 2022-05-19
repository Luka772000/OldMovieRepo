using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NlogInterface;
using ProjektFinal.DTOs;
using ProjektFinal.Models;


namespace ProjektFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly FilmContext _context;
        private readonly IMapper mapper;
        private readonly ILoggerManager _logger;

        public ActorsController(FilmContext context, IMapper mapper, ILoggerManager logger)
        {
            _context = context;
            this.mapper = mapper;
            //NLogger ubacen 
            _logger = logger;
        }

        /// <summary>
        /// Vraća listu glumaca
        /// </summary>
        /// <returns>Lista glumaca</returns>
        /// <remarks>
        /// Sample request
        /// GET/api/Glumci
        /// </remarks>


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDto>>> GetActors()
        {

            
            
            try
            {
                var actors = await _context.Actors.ToListAsync();
                var actorsDto = mapper.Map<IEnumerable<Actor>, IEnumerable<ActorDto>>(actors);
                
                return Ok(actorsDto);
            }
            catch(Exception ex)
            {
                // Nlogger kod try catch metode
                _logger.LogError($"Nesto je poslo po zlu u HttpGet(Glumac) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");

            }
        }
        /// <summary>
        /// Vraća glumca s  odredenim ID-om
        /// </summary>
        /// <returns>Glumac</returns>
        /// <remarks>
        /// Sample request
        /// GET/api/Glumci/2
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDto>> GetActorById(int id)
        {

            
            try
            {

                var actor= await _context.Actors.FindAsync(id);
                var actorDto = mapper.Map<Actor, ActorDto>(actor);
                if (actorDto == null)
                {
                    _logger.LogError($"Glumac sa unesenim ID-m nije pronadjen {id}");
                    return NotFound("Film sa unesenim ID-om nije pronaden");
                }

                return actorDto;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Nesto je poslo po zlu u HttpGetbyID(Glumac) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }
        }

        /// <summary>
        /// Updejta Glumca
        /// </summary>
        /// <returns>Glumac</returns>
        /// <remarks>
        /// Sample request
        /// Put/api/Glumac
        /// </remarks>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, ActorDto actorDto)
        {
            var actor = mapper.Map<ActorDto, Actor>(actorDto);
            if (id != actor.ActorID)
            {
                return BadRequest();
            }

            _context.Entry(actor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }



        /// <summary>
        /// Posta glumca
        /// </summary>
        /// <returns>Glumac</returns>
        /// <remarks>
        /// Sample request
        /// POST/api/Glumci
        /// </remarks>

        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(ActorDto actorDto)
        {

            
            try
            {

                var actor = mapper.Map<ActorDto, Actor>(actorDto);
                _context.Actors.Add(actor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetGlumac", new { id = actor.ActorID }, actor);
            }
            catch(Exception ex)
            {

                _logger.LogError($"Nesto je poslo po zlu u HttpPost(Glumac) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }

        }
        /// <summary>
        /// Brise glumca s  odredenim ID-om
        /// </summary>
        /// <returns>Glumac</returns>
        /// <remarks>
        /// Sample request
        /// DELETE/api/Glumci/2
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                var actor = await _context.Actors.FindAsync(id);
                if (actor == null)
                {
                    _logger.LogError($"Glumac sa unesenim ID-m nije pronadjen {id}");
                    return NotFound();
                }

                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {

                
                _logger.LogError($"Nesto je poslo po zlu u HttpDelete(Glumac) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }




        }
    }
}
