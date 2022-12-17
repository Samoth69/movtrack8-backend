namespace movtrack8_backend.Controllers
{
    /// <summary>
    /// Template de réponse aux requêtes
    /// </summary>
    /// <typeparam name="T">Objet passé à Responde</typeparam>
    public class PagedResponse<T> : Response<T>
    {
        /// <summary>
        /// Page actuelle
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Nombre d'élément dans une page
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Nombre total de page
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Nombre total d'élément
        /// </summary>
        public int TotalRecords { get; private set; }

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords) : base(data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        }
    }
}
