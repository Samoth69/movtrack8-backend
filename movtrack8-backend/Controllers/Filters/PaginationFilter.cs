using System.ComponentModel.DataAnnotations;

namespace movtrack8_backend.Controllers.Filters
{
    public class PaginationFilter
    {
        /// <summary>
        /// nombre max d'élément par page
        /// </summary>
        const int MAX_PAGE_SIZE = 500;

        /// <summary>
        /// numéro de page
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
        
        /// <summary>
        /// Nombre max d'élément par page (maximum autorisé: 500)
        /// </summary>
        [Range(1, MAX_PAGE_SIZE)]
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }

    public static class PaginationFilterExtension
    {
        /// <summary>
        /// Function d'extension pour LINQ
        /// Permet d'appliquer les page à la requête SQL
        /// </summary>
        /// <typeparam name="T">Type de db set</typeparam>
        /// <param name="query">Requête linq</param>
        /// <param name="pf">Paramètre de pagination</param>
        /// <returns></returns>
        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, PaginationFilter pf)
        {
            return query.Skip((pf.PageNumber - 1) * pf.PageSize)
                        .Take(pf.PageSize);
        }
    }
}
