using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shared.ErrorModels;
using System.Net;

namespace WebApplication1.Factories
{
    public class ApiResponseFactory
    {
       public static IActionResult CustomValidationErrorResponse(ActionContext context)
        {
            // context ==> ModelState ==> Dictionary <string , ModelStateEntry>
            // string ==> Key ==> name of param
            //ModelstateEntry ==> object ==> errors
            //1] get all errors in modelstate entry 
            //2]Create custom Response
            //3]return 
            var errors = context.ModelState.Where(error => error.Value.Errors.Any()).Select(error => new ValidationError
            {
                Field = error.Key,
                Errors = error.Value.Errors.Select(e => e.ErrorMessage)
            });
            var response = new ValidationErrorResponse()
            {
                Errors = errors,
                StatusCode = (int)HttpStatusCode.BadRequest,
                ErrorMessage = "invalid erros occur "
            };
            return new BadRequestObjectResult(response);
        }
    }
}
