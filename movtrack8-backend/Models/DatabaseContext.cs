using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using movtrack8_backend.Interfaces;
using movtrack8_backend.Utils;
using NodaTime;
using Npgsql;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace movtrack8_backend.Models
{
    /// <summary>
    /// Database context
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<TOeuvre> Oeuvres { get; set; }
        public DbSet<TEpisode> Episodes { get; set; }
        public DbSet<TWebsite> Websites { get; set; }

        private readonly IConfiguration _config;

        public DatabaseContext(IConfiguration config) : base()
        {
            _config = config;
            SavingChanges += EventSavingChanges;
        }

        /// <summary>
        /// Update CreatedAt and UpdatedAt properties when saving to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventSavingChanges(object? sender, SavingChangesEventArgs e)
        {
            Instant now = SystemClock.Instance.GetCurrentInstant();

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

                // trim toutes les propriétés de type string(ou string?) dans les objets avant la sauvegarde en bdd
                changedEntity.Entity.GetType().GetProperties().ForEach(x =>
                {
                    // saute les entrées qui contiennent le terme regex, on ne veut pas modifier un regex
                    if (x.Name.Contains("regex", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return;
                    }

                    var val = x.GetGetMethod()?.Invoke(changedEntity.Entity, null);
                    if (val is not null && val is string str)
                    {
                        string? trimmed = str.Trim();
                        if (trimmed.Length == 0)
                        {
                            // on définit l'entité comme null si le string peut être nullable,
                            if (StaticUtils.IsNullable(changedEntity.Entity))
                            {
                                trimmed = null;
                            }
                            else
                            {
                                trimmed = string.Empty;
                            }
                        }
                        object?[] arr = { trimmed };
                        x.GetSetMethod()?.Invoke(changedEntity.Entity, arr);
                    }
                });
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.GetConnectionString("movtrack7"), o =>
            {
                o.UseNodaTime();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // WebsiteId & JackettId unique ensemble
            modelBuilder.Entity<TEpisode>()
                .HasIndex(u => new { u.WebsiteId, u.JackettId })
                .IsUnique();

            // Many to many entres TEpisode et TTag
            modelBuilder.Entity<TEpisode>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Episodes)
                .UsingEntity<TEpisodeTTag>(
                    x => x
                        .HasOne(x => x.Tag)
                        .WithMany(x => x.EpisodeTags)
                        .HasForeignKey(x => x.TagId)
                        .OnDelete(DeleteBehavior.Cascade),
                    x => x
                        .HasOne(x => x.Episode)
                        .WithMany(x => x.EpisodeTags)
                        .HasForeignKey(x => x.EpisodeId)
                        .OnDelete(DeleteBehavior.Cascade),
                    x => x
                        // assure que un episode ne peux pas avoir deux fois le même tag
                        .HasIndex(x => new { x.EpisodeId, x.TagId })
                        .IsUnique()
                );
        }
    }
}
