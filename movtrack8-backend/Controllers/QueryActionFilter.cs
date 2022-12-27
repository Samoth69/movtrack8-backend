using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;
using movtrack8_backend.Utils;

namespace movtrack8_backend.Controllers
{
    /// <summary>
    /// Class qui fait les controles nécéssaire pour chaque requête
    /// </summary>
    public class QueryActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.Values.ForEach(model =>
            {
                // vérification sur l'objet
                if (model is ICheck check)
                {
                    context.Result = check.CheckObject();
                }

                // marque l'objet comme étant un patch si la requête est de type patch
                if (model is BaseDTO dto)
                {
                    if (context.HttpContext.Request.Method == "PATCH")
                    {
                        dto.MarkAsHttpPatchRequest();
                    }
                }
            });
        }
    }
}
