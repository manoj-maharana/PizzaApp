using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain.Interface.Models
{
    public class Pizza
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string TypeOfPizza { get; set; }
        public decimal Price { get; set; }
        public PizzaType PizzaSize { get; set; }

        public string Ingredient { get; set; }

       
    }
}
