using Application;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using ResponseHandling.WebApi.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace ResponseHandling.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarApp _carApp;
        public CarController(ICarApp carApp)
        {
            _carApp = carApp;
        }

        [SwaggerOperation(
         Summary = "Car registration",
         Description = "All fields are mandatory.")]
        [HttpPost]
        [HandleRequestResponse]
        public ActionResult Create([FromBody] Car car)
        {
            _carApp.Create(car);
            return Ok();
        }

        [SwaggerOperation(
         Summary = "Listing cars by name",
         Description = "the name field is mandatory.")]
        [HttpGet]
        [Route("getbyname")]
        [HandleRequestResponse(TypeResponse = ETypeRequestResponse.ResponseWithData)]
        public ActionResult GetByName(string name)
        {
            return Ok(_carApp.GetByName(name));
        }

        [SwaggerOperation(
           Summary = "List car by id",
           Description = "the id field is mandatory.")]
        [HttpGet]
        [Route("getbyid")]
        [HandleRequestResponse(TypeResponse = ETypeRequestResponse.ResponseWithData)]
        public ActionResult GetById(int id)
        {
            return Ok(_carApp.GetById(id));
        }
    }
}