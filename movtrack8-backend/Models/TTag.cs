using System.ComponentModel.DataAnnotations;

namespace movtrack8_backend.Models
{
    public class TTag : EntityBase
    {
        /// <summary>
        /// Nom du tag
        /// </summary>
        [MaxLength(64)]
        public string Name { get; set; }

        public string BackgroundColor { get; set; } = "#000000";

        public string ForegroundColor { get; set; } = "#FFFFFF";

        public string Regex { get; set; }

        public ICollection<TEpisode> Episodes { get; set; }
        public List<TEpisodeTTag> EpisodeTags { get; set; }
    }
}
