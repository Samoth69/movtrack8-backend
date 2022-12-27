using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace movtrack8_backend.DTO
{
    public class OeuvreDTO : BaseDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? OeuvreRegex { get; set; }

        [Required]
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
