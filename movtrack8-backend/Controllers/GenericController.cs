using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movtrack8_backend.Controllers.Filters;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace movtrack8_backend.Controllers
{
    /// <summary>
    /// Classe de base pour les ApiController
    /// Ajoute le support des requêtes de base de HTTP (GET, POST, PUT, DELETE)
    /// Implémente pour chaque endpoint des fonctionnalités de trie et de pagination
    /// </summary>
    /// <typeparam name="TDb">Objet EF Core</typeparam>
    /// <typeparam name="TDTO">Objet DTO</typeparam>
    public abstract class GenericController<TDb, TDTO> : ControllerBase
        where TDb : EntityBase
        where TDTO : BaseDTO
    {
        protected readonly DatabaseContext _db;
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;

        protected GenericController(ILogger logger, DatabaseContext databaseContext, IMapper mapper)
        {
            _logger = logger;
            _db = databaseContext;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(
            [FromQuery] PaginationFilter pageFilter,
            [FromQuery] OrderingFilter orderingFilter)
        {
            return await ApplyFilteringAndOrdering(_db.Set<TDb>(), pageFilter, orderingFilter);
        }

        protected async Task<IActionResult> ApplyFilteringAndOrdering(
            DbSet<TDb> query,
            PaginationFilter pageFilter,
            OrderingFilter orderingFilter)
        {
            var dbQuery = await query
                .ApplyOrdering(orderingFilter)
                .ApplyFiltering(pageFilter)
                .ProjectTo<TDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var totalRecords = await query.CountAsync();

            return Ok(new PagedResponse<List<TDTO>>(dbQuery, pageFilter.PageNumber, pageFilter.PageSize, totalRecords));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDTO>> GetId(long id)
        {
            var ret = await _db.Set<TDb>().FindAsync(id);

            if (ret == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TDTO>(ret));
        }

        [HttpPost]
        public async Task<ActionResult<TDTO>> Post([FromBody] TDTO dt)
        {
            var added = await _db.Set<TDb>().AddAsync(_mapper.Map<TDb>(dt));
            await _db.SaveChangesAsync();
            
            var DTO = _mapper.Map<TDTO>(added.Entity);
            return CreatedAtAction(nameof(GetId), new { DTO.Id }, DTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long Id, [FromBody] TDTO dto)
        {
            if (Id != dto.Id)
            {
                return BadRequest("L'id passé en paramètre ne correspond pas à celui contenu dans l'objet");
            }

            TDb? todoItem = await _db.Set<TDb>().FindAsync(Id);
            if (todoItem == null)
            {
                return NotFound("Ressource not found, check Id");
            }

            _mapper.Map(dto, todoItem);

            await _db.SaveChangesAsync();

            return Ok(_mapper.Map<TDTO>(todoItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var toDelete = await _db.Set<TDb>().FindAsync(Id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _db.Set<TDb>().Remove(toDelete);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(long Id, [FromBody] TDTO dto)
        {
            TDb? todoItem = await _db.Set<TDb>().FindAsync(Id);

            _mapper.Map(dto, todoItem);
            await _db.SaveChangesAsync();

            return Ok(_mapper.Map<TDTO>(todoItem));
        }
    }
}
