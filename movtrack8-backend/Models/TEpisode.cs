using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace movtrack8_backend.Models
{
    [Index(nameof(JackettId))]
    [Index(nameof(WebsiteId))]
    [Index(nameof(OeuvreId))]
    [Index(nameof(Title))]
    public class TEpisode : EntityBase
    {
        public TOeuvre Oeuvre { get; set; }
        public long OeuvreId { get; set; }

        public TWebsite Website { get; set; }
        public long WebsiteId { get; set; }

        public long JackettId { get; set; }

        public Instant PubDate { get; set; }

        public string Title { get; set; }
        public string WebsiteLink { get; set; }
        public string DlLink { get; set; }
        public long Size { get; set; }

        /// <summary>
        /// Status de l'episode
        /// 0: ok
        /// 1: mauvaise qualité (en dessous de 1080p et/ou encodage pourris)
        /// 2: Torrent suspect
        /// </summary>
        public int Status { get; set; } = 0;

        public string? Details { get; set; }

        public ICollection<TTag> Tags { get; set; }
        public List<TEpisodeTTag> EpisodeTags { get; set; }

        public ICollection<TCategory> Categories { get; set; }
        public List<TEpisodeTCategory> EpisodeCategories { get; set; }
    }
}
