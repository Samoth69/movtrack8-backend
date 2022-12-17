using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movtrack8_backend.Interfaces;
using System.Runtime.CompilerServices;

namespace movtrack8_backend.Models
{
    /// <summary>
    /// Base class for all tables in database
    /// </summary>
    /// <typeparam name="T">Type of the primary key</typeparam>
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public abstract class EntityBase : IObjectBase
    {
        /// <summary>
        /// Clé primaire
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// When this object was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When this object was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Database context
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<TOeuvre> Oeuvres { get; set; }

        public DatabaseContext() : base()
        {
            SavingChanges += EventSavingChanges;
        }

        /// <summary>
        /// Update CreatedAt and UpdatedAt properties when saving to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventSavingChanges(object? sender, SavingChangesEventArgs e)
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IObjectBase entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            entity.UpdatedAt = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                            entity.UpdatedAt = now;
                            break;
                    }
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=movtrack7;Username=postgres;Password=postgres");
        }
    }
}
