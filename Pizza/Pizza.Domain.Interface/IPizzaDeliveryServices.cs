using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Domain.Interface.Models;

namespace Pizza.Domain.Interface
{
    public interface IPizzaDeliveryServices
    {
        Task<IEnumerable<Interface.Models.Pizza>> GetAllPizzas();

        Task<Pizza.Domain.Interface.Models.Pizza> GetPizzaDetails(long id);

        Task<long> AddNewPizza(Pizza.Domain.Interface.Models.Pizza pizza);
    }
}
