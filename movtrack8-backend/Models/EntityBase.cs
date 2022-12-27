using Microsoft.EntityFrameworkCore;
using movtrack8_backend.Interfaces;
using NodaTime;

namespace movtrack8_backend.Models
{
    /// <summary>
    /// Base class for all tables in database
    /// </summary>
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public abstract class EntityBase : IObjectBase
    {
        /// <summary>
        /// Clé primaire
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// When this object was created
        /// </summary>
        public Instant? CreatedAt { get; set; }

        /// <summary>
        /// When this object was last updated
        /// </summary>
        public Instant? UpdatedAt { get; set; }
    }
}
