using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Data.Interface
{
    public interface IPizzaDeliveryData
    {
        Task<IEnumerable<Pizza.Data.Interface.Model.Pizza>> GetAllPizzas();

        Task<Pizza.Data.Interface.Model.Pizza> GetPizzaDetails(long id);

        Task<long> AddNewPizza(Pizza.Data.Interface.Model.Pizza pizza);

    }
}
