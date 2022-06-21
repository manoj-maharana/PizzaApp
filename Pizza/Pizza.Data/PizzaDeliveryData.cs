using Pizza.Data.Interface;

namespace Pizza.Data
{
    public class PizzaDeliveryData : IPizzaDeliveryData
    {
        public async Task<long> AddNewPizza(Interface.Model.Pizza pizza)
        {
            var getAllPizza = await GetAllPizzas().ConfigureAwait(false);

            var insertDate = new List<Interface.Model.Pizza>()
            {
                new Interface.Model.Pizza()
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Ingredient = pizza.Ingredient,
                    PizzaSize = pizza.PizzaSize,
                    Price = pizza.Price,
                    TypeOfPizza = pizza.TypeOfPizza,
                    Url = pizza.Url

                }
            };

            getAllPizza.ToList().AddRange(insertDate);

            //return the newly created id
            return pizza.Id;

        }

        public async Task<IEnumerable<Interface.Model.Pizza>> GetAllPizzas()
        {
            IEnumerable<Interface.Model.Pizza> ret = new List<Interface.Model.Pizza>()
           {
               new Interface.Model.Pizza()
               {
                   Id = 1,
                   Name ="Chicken Pizza",
                   Price = 500,
                   Url ="https://cdn.pixabay.com/photo/2017/02/15/10/57/pizza-2068272_960_720.jpg",
                   TypeOfPizza = "Chicken"
               },
               new Interface.Model.Pizza()
               {
                   Id = 2,
                   Name ="Veg Pizza",
                   Price = 300,
                   Url ="https://cdn.pixabay.com/photo/2017/12/09/08/18/pizza-3007395_960_720.jpg",
                   TypeOfPizza = "Veg"
               }

           };

            return ret;
        }

        public async Task<Interface.Model.Pizza> GetPizzaDetails(long id)
        {
            var getAllPizza = await GetAllPizzas();

            return getAllPizza.FirstOrDefault(x => x.Id == id);
        }


    }

}
