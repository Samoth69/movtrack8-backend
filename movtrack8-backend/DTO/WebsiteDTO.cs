using Microsoft.AspNetCore.Mvc;
using movtrack8_backend.Utils;
using System.ComponentModel.DataAnnotations;

namespace movtrack8_backend.DTO
{
    public class WebsiteDTO : BaseDTO
    {
        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? Name { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? MainAddress { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? RssAddress { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? WebsiteRegex { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public bool? Enabled { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public bool? CloudFlareProtected { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public DateTime LastSuccessfulFetch { get; set; }

        public override IActionResult? CheckObject()
        {
            return null;
        }
    }
}
