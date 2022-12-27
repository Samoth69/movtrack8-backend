using Microsoft.AspNetCore.Mvc;
using NodaTime;
using System.ComponentModel.DataAnnotations;

namespace movtrack8_backend.DTO
{
    public class EpisodeDTO : BaseDTO
    {
        [Required]
        public long? OeuvreId { get; set; }
        
        [Required]
        public long? WebsiteId { get; set; }

        [Required]
        public long? JackettId { get; set; }

        [Required]
        public Instant? PubDate { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? WebsiteLink { get; set; }
        
        [Required]
        public string? DlLink { get; set; }

        [Required]
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
