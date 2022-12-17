namespace movtrack8_backend.Controllers
{
    /// <summary>
    /// Structure des données retournées par les requêtes
    /// L'utilité de cette classe peut être discuté, mais elle permet d'ajouter par exemple un code d'erreur
    /// ou message spécifique aux requêtes utilisateurs
    /// </summary>
    /// <typeparam name="T">Type des données à renvoyer</typeparam>
    public class Response<T>
    {
        public T? Data { get; set; }

        public Response(T data)
        {
            Data = data;
        }
    }
}
