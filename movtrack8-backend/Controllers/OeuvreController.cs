using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movtrack8_backend.Controllers.Filters;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;
using System.ComponentModel;

namespace movtrack8_backend.Controllers
{
    [ApiController]
    [Route("backend/[controller]")]
    public class OeuvreController : GenericController<TOeuvre, OeuvreDTO>
    {
        public OeuvreController(ILogger<OeuvreController> logger, DatabaseContext databaseContext, IMapper mapper) :
            base(logger, databaseContext, mapper)
        {
        }
    }
}
