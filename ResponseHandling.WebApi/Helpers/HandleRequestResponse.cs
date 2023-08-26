using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Application.Helpers;
using System.Collections;

namespace ResponseHandling.WebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HandleRequestResponse : ActionFilterAttribute
    {
        public ETypeRequestResponse TypeResponse { get; set; }

        /// <summary>
        /// After a resquest 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is null)
            {
                object valueResult = null;

                if (context.Result is OkObjectResult objectResult)
                    valueResult = objectResult.Value;

                if (TypeResponse == ETypeRequestResponse.ResponseWithData)
                {
                    if (!IsValue(valueResult))
                        context.Result = new NotFoundResult();
                }
            }
            else if (context.Exception is ResponseException exceptionResponse)
            {
                context.Result = Handled(exceptionResponse);
                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new InternalServerErrorObjectResult();
                context.ExceptionHandled = true;
            }

            base.OnActionExecuted(context);
        }
 
        private static IActionResult Handled(ResponseException exceptionResponse)
        {
            string message = string.IsNullOrWhiteSpace(exceptionResponse.Message) ? string.Empty : exceptionResponse.Message;

            switch (exceptionResponse.Code)
            {
                case EResponse.Accepted:
                    return new AcceptedResult();
                case EResponse.BadRequest:
                    return new BadRequestObjectResult(message);
                case EResponse.Unauthorized:
                    return new UnauthorizedObjectResult(message);
                case EResponse.Forbidden:
                    return new ForbidResult();
                case EResponse.NotFound:
                    return new NotFoundObjectResult(message);
                case EResponse.InternalServerError:
                    return new InternalServerErrorObjectResult();
            }

            return new OkResult();
        }


        /// <summary>
        /// Check if is value 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsValue(object value)
        {
            if (value is null) return false;

            if (value is ICollection collection && collection.Count == 0) return false;

            return true;
        }
    }
}
