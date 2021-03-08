using FluentAssertions;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationTests.SharedSteps;
using System;
using System.Net;
using Xunit;

namespace SwaggerPetStoreAutomationTests.StoreTests
{
    public class OrderTests
    {

        [Fact]
        public void VerifyPetInventoryOrderStatus()
        {
            var pet = PetsSharedSteps.CreatePet("Cocoa", PetStatus.available);
            var orderCreated = OrderSharedSteps.CreateOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.delivered, 1, true);
            orderCreated.Complete.Should().BeTrue();
            var response = OrderActions.PetInventoryByStatus();
            response.Approved.Should().BeGreaterThan(50);
        }

        [Fact]
        public void OrderCRUDTest()
        {
            var pet = PetsSharedSteps.CreatePet("Jelly", PetStatus.available);
            var orderCreated = OrderSharedSteps.CreateOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.placed, 1, true);
            orderCreated.Complete.Should().BeTrue();
            var order = OrderActions.FindPurchaseOrderById(orderCreated.Id);
            order.Id.Should().Be(orderCreated.Id);
            OrderActions.DeletePurchaseOrderById(orderCreated.Id, HttpStatusCode.OK);
        }
    }
}
