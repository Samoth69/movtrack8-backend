using NodaTime;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace movtrack8_backend.Models
{
    public class TWebsite : EntityBase
    {
        /// <summary>
        /// Nom du site web
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Addresse du site web
        /// </summary>
        public string MainAddress { get; set; }

        /// <summary>
        /// Address du flux RSS
        /// </summary>
        public string? RssAddress { get; set; }

        /// <summary>
        /// Regex pour match le site
        /// </summary>
        public string? WebsiteRegex { get; set; }

        /// <summary>
        /// Si le fetch RSS doit être activé pour ce site
        /// </summary>
        [DefaultValue(true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Vrai si le site est protégé par le IUAM de cloudflare
        /// </summary>
        [DefaultValue(false)]
        public bool CloudFlareProtected { get; set; }
        
        /// <summary>
        /// Dernier fetch rss sans erreurs
        /// </summary>
        public Instant LastSuccessfulFetch { get; set; } = SystemClock.Instance.GetCurrentInstant();

        public List<TEpisode> Episodes { get; set; }
    }
}
