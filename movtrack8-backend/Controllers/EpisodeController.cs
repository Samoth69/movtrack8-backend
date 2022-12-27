using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;

namespace movtrack8_backend.Controllers
{
    [ApiController]
    [Route("backend/[controller]")]
    public class EpisodeController : GenericController<TEpisode, EpisodeDTO>
    {
        public EpisodeController(ILogger<EpisodeController> logger, DatabaseContext databaseContext, IMapper mapper) :
            base(logger, databaseContext, mapper)
        {
        }    
    }
}
