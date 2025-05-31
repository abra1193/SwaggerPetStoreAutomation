using System;
using System.Net;
using FluentAssertions;
using Serilog;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationTests.BaseTests;
using Xunit;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationTests.Tests.OrderTests
{
    public class OrderTests : BaseClass
    {

        public OrderTests(ITestOutputHelper outputHelper) : base(outputHelper) { }

        [Fact]
        public void VerifyPetInventoryOrderStatus()
        {
            Log.Information("Verify Order Status are updated on the Pet Inventory endpoint");
            var pet = SharedSteps.PetsSharedSteps.CreatePet("Cocoa", PetStatus.available);
            var orderCreated = SharedSteps.OrderSharedSteps.CreateOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.Delivered, 1, true);
            orderCreated.Complete.Should().BeTrue();
            var response = Actions.OrderActions.PetInventoryByStatus();
            response.Approved.Should().BeGreaterOrEqualTo(0);
        }

        [Fact]
        public void OrderCRUDTest()
        {
            Log.Information("Verify Order can be created/Updated/Deleted");
            var pet = SharedSteps.PetsSharedSteps.CreatePet("Jelly", PetStatus.available);
            var orderCreated = SharedSteps.OrderSharedSteps.CreateOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.Placed, 1, true);
            orderCreated.Complete.Should().BeTrue();
            var order = Actions.OrderActions.FindPurchaseOrderById(orderCreated.Id);
            order.Id.Should().Be(orderCreated.Id);
            Actions.OrderActions.DeletePurchaseOrderById(orderCreated.Id, HttpStatusCode.OK);
        }
    }
}