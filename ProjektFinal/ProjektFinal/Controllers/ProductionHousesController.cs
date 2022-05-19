using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NlogInterface;
using ProjektFinal.DTOs;
using ProjektFinal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProjektFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionHousesController : ControllerBase
    {
        private readonly FilmContext _context;
        private readonly IMapper mapper;
        private readonly ILoggerManager _logger;
        public ProductionHousesController(FilmContext context, IMapper mapper, ILoggerManager logger)
        {
            _context = context;
            this.mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Vraća listu produkcijskih kuca
        /// </summary>
        /// <returns>Lista produkcijskih kuca</returns>
        /// <remarks>
        /// Sample request
        /// GET/api/ProdKuca
        /// </remarks>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionHouseDto>>> GetProdKuca()
        {


            try
            {
                var productionhouse = await _context.ProductionHouses.ToListAsync();
                var productionhouseDto = mapper.Map<IEnumerable<ProductionHouse>, IEnumerable<ProductionHouseDto>>(productionhouse);
                return Ok(productionhouseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Nesto je poslo po zlu u HttpGet(ProdKuca) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");

            }
        }
        /// <summary>
        /// Vraća produkcijsku kucu po id-u
        /// </summary>
        /// <returns>Produkcijska kuca</returns>
        /// <remarks>
        /// Sample request
        /// GET/api/ProdKuca/2
        /// </remarks>


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionHouseDto>> GetProdkuca(int id)
        {


            try
            {

                var productionhouse = await _context.ProductionHouses.FindAsync(id);
                var productionhouseDto = mapper.Map<ProductionHouse, ProductionHouseDto>(productionhouse);
                if (productionhouseDto == null)
                {
                    _logger.LogError($"ProdKuca sa unesenim ID-m nije pronadjen {id}");
                    return NotFound("Film sa unesenim ID-om nije pronaden");
                }

                return productionhouseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Nesto je poslo po zlu u HttpGetByID(ProdKuca) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }
        }

        /// <summary>
        /// Updejta produkcijsku kucu
        /// </summary>
        /// <returns>Produkcijska kuca</returns>
        /// <remarks>
        /// Sample request
        /// PUT/api/ProdKuca
        /// </remarks>
        [HttpPut("{id}")]


        public async Task<IActionResult> PutProdKuca(int id, ProductionHouseDto productionhouseDto)
        {
            var productionhouse = mapper.Map<ProductionHouseDto, ProductionHouse>(productionhouseDto);
            if (id != productionhouse.KucaID)
            {
                return BadRequest();
            }

            _context.Entry(productionhouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Posta produkcijsku kucu
        /// </summary>
        /// <returns>Produkcijska kuca</returns>
        /// <remarks>
        /// Sample request
        /// POST/api/ProdKuca
        /// </remarks>

        [HttpPost]
        public async Task<ActionResult<Actor>> PostProdKuca(ProductionHouseDto productionhouseDto)
        {


            try
            {

                var productionhouse = mapper.Map<ProductionHouseDto, ProductionHouse>(productionhouseDto);
                _context.ProductionHouses.Add(productionhouse);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProdkuca", new { id = productionhouse.KucaID }, productionhouse);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Nesto je poslo po zlu u HttpPost(ProdKuca) metodi: {ex.Message}");
                return BadRequest("An exception was thrown");
            }

        }

        /// <summary>
        /// Brise prodkucu po ID-u
        /// </summary>
        /// <returns>Produkcijska kuca izbrisana</returns>
        /// <remarks>
        /// Sample request
        /// DELETE/api/ProdKuca
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdKuca(int id)
        {
            try
            {
                var productionhouse = await _context.ProductionHouses.FindAsync(id);
                if (productionhouse == null)
                {
                    _logger.LogError($"ProdKuca sa unesenim ID-m nije pronadjen {id}");
                    return NotFound();
                }

                _context.ProductionHouses.Remove(productionhouse);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Nesto je poslo po zlu u HttpDelete(ProdKuca) metodi: {ex.Message}");
                return BadRequest("An exception was thrown ");

            }
        }



    }
}
