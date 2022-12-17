using movtrack8_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace movtrack8_backend.Controllers.Filters
{
    /// <summary>
    /// Trie les résultats avec le paramètre suivant
    /// </summary>
    public enum EOrderBy : byte
    {
        [EnumMember(Value = "Id")]
        Id = 0,
        [EnumMember(Value = "CreatedAt")]
        CreatedAt = 1,
        [EnumMember(Value = "UpdatedAt")]
        UpdatedAt = 2
    }

    /// <summary>
    /// Indique le sens du tri
    /// </summary>
    public enum EOrderDirection : byte
    {
        [EnumMember(Value = "ASC")]
        Asc = 0,
        [EnumMember(Value = "DESC")]
        Desc = 1
    }

    /// <summary>
    /// Paramètre de trie pour la requête
    /// </summary>
    public class OrderingFilter
    {
        /// <summary>
        /// Trie les résultats avec le paramètre suivant
        /// </summary>
        public EOrderBy OrderBy { get; set; }

        /// <summary>
        /// Indique le sens du tri
        /// </summary>
        public EOrderDirection OrderDirection { get; set; }

        public OrderingFilter()
        {
            OrderBy = EOrderBy.Id;
            OrderDirection = EOrderDirection.Asc;
        }
    }

    public static class ApplyOrderingClass
    {
        /// <summary>
        /// Fonction d'extension pour LINQ
        /// Permet d'appliquer la config de tri sur une requête LINQ
        /// </summary>
        /// <typeparam name="T">Type de db set (doit étendre EntityBase)</typeparam>
        /// <param name="query">Requête linq</param>
        /// <param name="of">Paramètre de tri</param>
        /// <returns></returns>
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, OrderingFilter of) where T : EntityBase
        {
            query = of.OrderBy switch
            {
                EOrderBy.CreatedAt => query.OrderBy(x => x.CreatedAt),
                EOrderBy.UpdatedAt => query.OrderBy(x => x.UpdatedAt),
                _ => query.OrderBy(x => x.Id),
            };
            if (of.OrderDirection == EOrderDirection.Desc)
            {
                query = query.Reverse();
            }
            return query;
        }
    }
}
