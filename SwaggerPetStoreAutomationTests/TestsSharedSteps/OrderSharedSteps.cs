using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationAPI.Helpers;

namespace SwaggerPetStoreAutomationTests.SharedSteps
{
    public class OrderSharedSteps : OrderActions
    {

        public Order InitializeOrder(int petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete)
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
            var orderToCreate = order;
            if (orderToCreate == null) orderToCreate = InitializeOrder(petId, shipDate, orderStatus, quantity, complete);
            return PlaceAnOrderForAPet(orderToCreate);
        }
    }
}
