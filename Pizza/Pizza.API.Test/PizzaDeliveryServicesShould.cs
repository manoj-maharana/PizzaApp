

namespace Pizza.API.Test
{
    public class PizzaDeliveryServicesShould
    {
        private Mock<IPizzaDeliveryData> mockPizzaDeliveryData;
        private Mock<IMapper> mockMapper;

        private IPizzaDeliveryServices pizzaDeliveryServices;

        public PizzaDeliveryServicesShould()
        {
            mockPizzaDeliveryData = new Mock<IPizzaDeliveryData>();
            mockMapper = new Mock<IMapper>();
            pizzaDeliveryServices = new PizzaDeliveryServices(mockPizzaDeliveryData.Object, mockMapper.Object);
        }

        [Fact]
        public void VerifyPizzaDelivery_Get_All()
        {
            //Arrange
            mockPizzaDeliveryData.Setup(x => x.GetAllPizzas()).Returns(GetMockAllPizzaList());

            //Act
            var getAllPizza =  pizzaDeliveryServices.GetAllPizzas();

            //Assert

            Assert.NotNull(getAllPizza);
            //Assert.Equal(2, getAllPizza.Count);
        }

        [Fact]
        public void VerifyPizzaDelivery_Get_Details()
        {
            //Arrange
          
            mockPizzaDeliveryData.Setup(x => x.GetPizzaDetails(It.IsAny<long>())).Returns(GetMockAllPizzaDetails());

            //Act
            var getAllPizza = pizzaDeliveryServices.GetPizzaDetails(1);

            //Assert

            Assert.NotNull(getAllPizza);
            
        }


        private static async Task<IEnumerable<Pizza.Data.Interface.Model.Pizza>> GetMockAllPizzaList()
        {
            IEnumerable<Pizza.Data.Interface.Model.Pizza> ret = new List<Pizza.Data.Interface.Model.Pizza>()
           {
               new Pizza.Data.Interface.Model.Pizza()
               {
                   Id = 1,
                   Name ="Chicken Pizza",
                   Price = 500,
                   Url ="https://cdn.pixabay.com/photo/2017/02/15/10/57/pizza-2068272_960_720.jpg",
                   TypeOfPizza = "Chicken"
               },
               new Pizza.Data.Interface.Model.Pizza()
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

        private static async Task<Pizza.Data.Interface.Model.Pizza> GetMockAllPizzaDetails()
        {
            Pizza.Data.Interface.Model.Pizza ret =
               new Pizza.Data.Interface.Model.Pizza()
               {
                   Id = 1,
                   Name = "Chicken Pizza",
                   Price = 500,
                   Url = "https://cdn.pixabay.com/photo/2017/02/15/10/57/pizza-2068272_960_720.jpg",
                   TypeOfPizza = "Chicken"
               };
              

         

            return ret;
        }
    }
}
