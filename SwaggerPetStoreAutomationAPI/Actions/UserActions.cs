using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationAPI.Helpers;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class UserActions
    {
        public Users CreateUser(Users body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.CreateUser);
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            if (request.Body != null) Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Users>(response);
        }

        public string LogIn(string userName, string password, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.LogInUser);
            var request = rawRequest.PrepareGETRequest();
            request.AddQueryParameter("username",userName);
            request.AddQueryParameter("password", password);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(response.Content);
            return response.Content;
        }

        public string LogOut(HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.LogOutUser);
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(response.Content);
            return response.Content;
        }

        public Users GetUserByUsername(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.GetUserByUsername);
            var request = rawRequest.PrepareGETRequest();
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Users>(response);
        }

        public Users UpdateUser(Users body, string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.GetUserByUsername);
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePUTRequest(jsonBody);
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            if (request.Body != null) Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Users>(response);
        }

        public string DeleteUser(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.GetUserByUsername);
            var request = rawRequest.PrepareDELETERequest();
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(response.Content);
            return response.Content;
        }
    }
}