namespace Pizza.API.Models
{
    public class Pizza
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string TypeOfPizza { get; set; } = null!;
        public decimal Price { get; set; }
        public PizzaType PizzaSize { get; set; } = null!;

        public string Ingredient { get; set; } = null!;
    }
}
