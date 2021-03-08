using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Entities;
using System;

namespace SwaggerPetStoreAutomationTests.SharedSteps
{
    public class OrderSharedSteps
    {
        public static Order InitializeOrder(int petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete)
        {
            var random = new Random();
            return new Order()
            {
                Id = random.Next(1, 100),
                PetId = petId,
                Quantity = quantity,
                ShipDate = shipDate,
                Status = orderStatus.ToString(),
                Complete = complete
            };
        }

        public static Order CreateOrder(int petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete, Order order = null)
        {
            var orderToCreate = order;
            if (orderToCreate == null) orderToCreate = InitializeOrder(petId, shipDate, orderStatus, quantity, complete);
            return OrderActions.PlaceAnOrderForAPet(orderToCreate);
        }
    }
}
