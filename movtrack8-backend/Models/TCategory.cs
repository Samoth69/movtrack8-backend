using Microsoft.EntityFrameworkCore;

namespace movtrack8_backend.Models
{
    [Index(nameof(WebsiteSlug))]
    public class TCategory : EntityBase
    {
        public TWebsite Website { get; set; }
        public long WebsiteId { get; set; }

        public string WebsiteSlug { get; set; }

        public string Name { get; set; }
    }
}
