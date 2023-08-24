using Application;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using ResponseHandling.WebApi.Helpers;

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

        [HttpPost]
        [HandleRequestResponse]
        public ActionResult Create([FromBody] Car car)
        {
            _carApp.Create(car);
            return Ok();
        }

        [HttpGet]
        [Route("getbyname")]
        [HandleRequestResponse(TypeResponse = ETypeRequestResponse.ResponseWithData)]
        public ActionResult GetByName(string name)
        {
            return Ok(_carApp.GetByName(name));
        }

        [HttpGet]
        [Route("getbyid")]
        [HandleRequestResponse(TypeResponse = ETypeRequestResponse.ResponseWithData)]
        public ActionResult GetById(int id)
        {
            return Ok(_carApp.GetById(id));
        }
    }
}
