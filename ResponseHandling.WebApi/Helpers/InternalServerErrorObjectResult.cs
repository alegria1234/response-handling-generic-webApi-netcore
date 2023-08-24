using Microsoft.AspNetCore.Mvc;

namespace ResponseHandling.WebApi.Helpers
{
    public class InternalServerErrorObjectResult :  ObjectResult
    {
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        public InternalServerErrorObjectResult() : this("Internal Server Error")
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
