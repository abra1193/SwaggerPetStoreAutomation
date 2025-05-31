using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationAPI.Helpers;

namespace SwaggerPetStoreAutomationTests.TestsSharedSteps
{
    public class OrderSharedSteps : OrderActions
    {
        private static Order InitializeOrder(int petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete)
        {
            return new Order()
            {
                Id = int.Parse(Randomizer.GenerateRandomId()),
                PetId = petId,
                Quantity = quantity,
                ShipDate = shipDate,
                Status = orderStatus.ToString(),
                Complete = complete
            };
        }

        public Order CreateOrder(int petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete, Order order = null)
        {
            var orderToCreate = order ?? InitializeOrder(petId, shipDate, orderStatus, quantity, complete);
            return PlaceAnOrderForAPet(orderToCreate);
        }
    }
}
