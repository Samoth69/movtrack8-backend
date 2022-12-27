using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static movtrack8_backend.Models.DatabaseContext;

namespace movtrack8_backend.Models
{
    public class TOeuvre : EntityBase
    {
        /// <summary>
        /// Nom de l'oeuvre
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Regex utilisé par le bot pour trouver des torrents liée à cette entités.
        /// Si null, le bot ne cherchera pas de torrent pour cette entité
        /// </summary>
        public string? OeuvreRegex { get; set; }
        
        /// <summary>
        /// Permet de désactiver la recherche de torrent pour cette entité
        /// </summary>
        [DefaultValue(false)]
        public bool IsDisabled { get; set; }

        /// <summary>
        /// Episodes liées à cette Oeuvre
        /// </summary>
        public List<TEpisode> Episodes { get; set; }
    }
}
