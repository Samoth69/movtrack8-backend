using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;
using System.ComponentModel;

namespace movtrack8_backend.Controllers
{
    [ApiController]
    [Route("backend/[controller]")]
    public class OeuvreController : GenericController<TOeuvre>
    {
        private readonly ILogger<OeuvreController> _logger;
        private readonly DatabaseContext _databaseContext;

        public OeuvreController(ILogger<OeuvreController> logger, DatabaseContext databaseContext, IMapper mapper) :
            base(logger, databaseContext, mapper)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TOeuvre>> GetOeuvreId(long Id)
        {
            var oeuvre = await _databaseContext.Oeuvres.FindAsync(Id);

            if (oeuvre == null)
            {
                return NotFound();
            }

            return oeuvre;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostOeuvre([FromBody] TOeuvre oeuvre)
        {
            _databaseContext.Oeuvres.Add(oeuvre);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOeuvreId), new { oeuvre.Id }, oeuvre);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutOeuvre(long Id, [FromBody] OeuvreDTO oeuvre)
        {
            if (Id != oeuvre.Id)
            {
                return BadRequest("L'id passé en paramètre ne correspond pas à celui contenu dans l'objet");
            }

            TOeuvre? todoItem = await _db.Oeuvres.FindAsync(Id);
            if (todoItem == null)
            {
                return NotFound("Ressource not found, check Id");
            }
            
            _mapper.Map(oeuvre, todoItem);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!OeuvreExists(Id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool OeuvreExists(long Id)
        {
            return _databaseContext.Oeuvres.Any(e => e.Id == Id);
        }

    }
}
