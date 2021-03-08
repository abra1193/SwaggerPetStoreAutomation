using FluentAssertions;
using Serilog;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationAPI.Entities;
using System;
using System.Net;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class OrderActions
    {
        public static Order PlaceAnOrderForAPet(Order body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Order>();
            var url = rawRequest.SetUrl("store/order");
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Order>(response);
        }

        public static PetInventoryStatus PetInventoryByStatus(HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<PetInventoryStatus>();
            var url = rawRequest.SetUrl("store/inventory");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<PetInventoryStatus>(response);
        }

        public static string DeletePurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl($"store/order/{orderId}");
            var request = rawRequest.PrepareDELETERequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return response.Content;
        }

        public static Order FindPurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl($"store/order/{orderId}");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Order>(response);
        }
    }
}