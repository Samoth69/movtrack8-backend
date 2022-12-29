using Microsoft.AspNetCore.Mvc;
using movtrack8_backend.Utils;
using NodaTime;
using System.ComponentModel.DataAnnotations;

namespace movtrack8_backend.DTO
{
    public class EpisodeDTO : BaseDTO
    {
        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public long? OeuvreId { get; set; }
        
        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public long? WebsiteId { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public long? JackettId { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public Instant? PubDate { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? Title { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? WebsiteLink { get; set; }
        
        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? DlLink { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public long? Size { get; set; }
        
        public int Status { get; set; } = 0;
        
        public string? Details { get; set; }

        public override IActionResult? CheckObject()
        {
            if (Size < 0)
            {
                Size = 0;
            }

            return null;
        }
    }
}
