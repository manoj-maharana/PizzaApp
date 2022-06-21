using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.API.Extensions;
using Pizza.Domain.Interface;

namespace Pizza.API.Controllers
{   

    [EnableCors("AllowOrigin")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaDeliveryServices pizzaDeliveryServices;
        private readonly ILogger<PizzaController> logger;
        public PizzaController(IPizzaDeliveryServices pizzaDeliveryServices,ILogger<PizzaController> logger)
        {
            this.pizzaDeliveryServices = pizzaDeliveryServices;
            this.logger = logger;
        }

        [HttpGet]
        [Route("getallpizza")]
        public async Task<IActionResult> GetAllPizzas()
        {
           
            var pizzas = await pizzaDeliveryServices.GetAllPizzas().ConfigureAwait(false);
            logger.LogInformation($"Get all the pizzas");

            return Ok(pizzas);
        }

        [HttpPost]
        [Route("createnewpizza")]
        public async Task<IActionResult> CreateNewPizza([FromBody] Pizza.API.Models.Pizza request)
        {
            ValidateRequests.ValidatePizzaRequest(request);

            var addnewPizza = new Pizza.Domain.Interface.Models.Pizza()
            {
                Name = request.Name,
                Id = request.Id,
                Ingredient = request.Ingredient,
               PizzaSize   = new Domain.Interface.Models.PizzaType()
               {
                   Id = request.PizzaSize.Id,
                   Name = request.PizzaSize.Name,
                   Price = request.PizzaSize.Price,
                   Type = request.PizzaSize.Type
               },
                Price = request.Price,
                TypeOfPizza = request.TypeOfPizza,
                Url = request.Url
            };
            var pizzas = await pizzaDeliveryServices.AddNewPizza(addnewPizza).ConfigureAwait(false);

            return Ok(pizzas);
        }

        [HttpGet]
        [Route("pizzadetails")]
        public async Task<IActionResult> GetPizzaDetails(long id)
        {
            var pizzas = await pizzaDeliveryServices.GetPizzaDetails(id).ConfigureAwait(false);
            logger.LogInformation($"Get pizza details");

            return Ok(pizzas);
        }

        // future work ingredient wise pizza


        //[HttpGet]
        //[Route("pizzaingredientsdetails")]
        //public async Task<IActionResult> GetPizzaIngredientsDetails(long id)
        //{
        //  // Not Implemented
        //}


    }
}
