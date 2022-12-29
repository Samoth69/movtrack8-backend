namespace movtrack8_backend.Models
{
    /// <summary>
    /// Table de lien entres les episodes et les tags
    /// </summary>
    public class TEpisodeTTag : EntityBase
    {
        public long EpisodeId { get; set; }
        public TEpisode Episode { get; set; }

        public long TagId { get; set; }
        public TTag Tag { get; set; }
    }
}
