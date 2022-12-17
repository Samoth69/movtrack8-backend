using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movtrack8_backend.Controllers.Filters;
using movtrack8_backend.Models;

namespace movtrack8_backend.Controllers
{

    public abstract class GenericController<T> : ControllerBase
        where T : EntityBase
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

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns><see cref="TOeuvre" /></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery] PaginationFilter pageFilter,
            [FromQuery] OrderingFilter orderingFilter)
        {
            var pagedData = await _db.Set<T>()
                .ApplyOrdering(orderingFilter)
                .ApplyFiltering(pageFilter)
                .ToListAsync();
            var totalRecords = await _db.Set<T>().CountAsync();
            return Ok(new PagedResponse<List<T>>(pagedData, pageFilter.PageNumber, pageFilter.PageSize, totalRecords));
        }
    }
}
