using AutoMapper;
using Pizza.Data.Interface;
using Pizza.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain
{
    public class PizzaDeliveryServices : IPizzaDeliveryServices
    {
        private readonly IPizzaDeliveryData pizzaDeliveryData;
        private readonly IMapper _mapper;
        public PizzaDeliveryServices(IPizzaDeliveryData pizzaDeliveryData, IMapper mapper)
        {
            this.pizzaDeliveryData = pizzaDeliveryData;
            _mapper = mapper;
        }
        public async Task<long> AddNewPizza(Interface.Models.Pizza pizza)
        {
            var addNewPizza = new Pizza.Data.Interface.Model.Pizza()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Ingredient = pizza.Ingredient,

                PizzaSize = new Pizza.Data.Interface.Model.PizzaType()
                {
                    Id = pizza.PizzaSize.Id,
                    Name = pizza.PizzaSize.Name,
                    Price = pizza.PizzaSize.Price,
                    Type = pizza.PizzaSize.Type
                },
                Price = pizza.Price,
                TypeOfPizza = pizza.TypeOfPizza,
                Url = pizza.Url

            };

            var ret = await pizzaDeliveryData.AddNewPizza(addNewPizza);

            return addNewPizza.Id;
        }

        public async Task<IEnumerable<Interface.Models.Pizza>> GetAllPizzas()
        {
            var ret = await pizzaDeliveryData.GetAllPizzas();
            if (ret == null)
                throw new ArgumentException("No pizza available");

            IEnumerable<Interface.Models.Pizza> mappedData = _mapper.Map<IEnumerable<Interface.Models.Pizza>>(ret);
            return mappedData;

        }

        public async Task<Interface.Models.Pizza> GetPizzaDetails(long id)
        {          

            Data.Interface.Model.Pizza? ret = await pizzaDeliveryData.GetPizzaDetails(id);
            if (ret == null)
                throw new ArgumentException("pizza details not available");

            Interface.Models.Pizza mappedData = _mapper.Map<Interface.Models.Pizza>(ret);
            return mappedData;
        }


    }
}
