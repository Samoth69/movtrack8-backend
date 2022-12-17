using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;

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
            if (context.ActionArguments.Count > 0)
            {
                var model = context.ActionArguments.Values.First();

                if (model is ICheck check)
                {
                    context.Result = check.CheckObject();
                }
            }
        }
    }
}
