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

        public ICollection<TEpisode> Episodes { get; set; }
        public List<TEpisodeTCategory> EpisodeCategories { get; set; }

        public string ImagePath { get; set; }

        public bool Show { get; set; } = false;
    }
}
