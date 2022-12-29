using Microsoft.AspNetCore.Mvc;
using movtrack8_backend.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace movtrack8_backend.DTO
{
    public class OeuvreDTO : BaseDTO
    {
        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? Name { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public string? OeuvreRegex { get; set; }

        [RequiredIfFalse(nameof(_IsHttpPatch))]
        public bool? IsDisabled { get; set; }

        public override IActionResult? CheckObject()
        {
            if (OeuvreRegex is not null)
            {
                try
                {
                    Regex.Match("", OeuvreRegex);
                }
                catch (ArgumentException)
                {
                    return new BadRequestResult();
                }
            }

            return null;
        }
    }
}
