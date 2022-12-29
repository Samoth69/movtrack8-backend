namespace movtrack8_backend.Models
{
    public class TEpisodeTCategory : EntityBase
    {
        public long EpisodeId { get; set; }
        public TEpisode Episode { get; set; }
        public long CategoryId { get; set; }
        public TCategory Category { get; set; }
    }
}
