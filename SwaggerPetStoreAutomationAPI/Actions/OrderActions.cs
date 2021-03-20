using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationAPI.Helpers;
using System.Net;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class OrderActions
    {
        public Order PlaceAnOrderForAPet(Order body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Order>();
            var url = rawRequest.SetUrl(PetStoreUrls.PlaceAnOrderForAPet);
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            if (request.Body != null) Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Order>(response);
        }

        public PetInventoryStatus PetInventoryByStatus(HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<PetInventoryStatus>();
            var url = rawRequest.SetUrl(PetStoreUrls.PetInventoryByStatus);
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            if (request.Body != null) Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<PetInventoryStatus>(response);
        }

        public string DeletePurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Order>();
            var url = rawRequest.SetUrl(PetStoreUrls.DeletePurchaseOrderById);
            var request = rawRequest.PrepareDELETERequest();
            request.AddUrlSegment("orderId",orderId);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(response.Content);
            return response.Content;
        }

        public Order FindPurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Order>();
            var url = rawRequest.SetUrl(PetStoreUrls.DeletePurchaseOrderById);
            var request = rawRequest.PrepareGETRequest();
            request.AddUrlSegment("orderId", orderId);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            if (request.Body != null) Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Order>(response);
        }
    }
}