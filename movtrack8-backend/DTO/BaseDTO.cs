using Microsoft.AspNetCore.Mvc;
using movtrack8_backend.Interfaces;
using movtrack8_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace movtrack8_backend.DTO
{
    /// <summary>
    /// Contient la/les fonctions qui sont utilisé pour vérifier que le contenu des objets
    /// correspond au attentes, permet de faire des tests plus poussées
    /// </summary>
    public interface ICheck
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Null if ok everything or ErrorCode with details, if an error is returned, this should be sent
        /// back to the client</returns>
        IActionResult? CheckObject();
    }

    /// <summary>
    /// Base class for all DTO Object, properties have the meaning as <see cref="EntityBase"/>
    /// </summary>
    public abstract class BaseDTO : IObjectBase, ICheck
    {
        public long? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Sera vrai si la requête actuelle est un http patch.
        /// permet de faire sauter la validation sur les champs qui ne sont pas fournis
        /// </summary>
#pragma warning disable IDE1006 // Naming Styles
        [JsonIgnore]
        public bool _IsHttpPatch { get; set; } = false;
#pragma warning restore IDE1006 // Naming Styles

        public abstract IActionResult? CheckObject();
    }
}
