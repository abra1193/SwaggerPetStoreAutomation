using System.Net;
using FluentAssertions;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationAPI.Entities;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class OrderActions
    {
        public Order PlaceAnOrderForAPet(Order body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Order>();
            var url = rawRequest.SetUrl("store/order");
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Order>(response);
        }

        public PetInventoryStatus PetInventoryByStatus(HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<PetInventoryStatus>();
            var url = rawRequest.SetUrl("store/inventory");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<PetInventoryStatus>(response);
        }

        public string DeletePurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Order>();
            var url = rawRequest.SetUrl($"store/order/{orderId}");
            var request = rawRequest.PrepareDELETERequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return response.Content;
        }

        public Order FindPurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Order>();
            var url = rawRequest.SetUrl($"store/order/{orderId}");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Order>(response);
        }
    }
}