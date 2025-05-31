using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using SwaggerPetStoreAutomationAPI.Controllers;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationAPI.Handlers;
using SwaggerPetStoreAutomationAPI.Helpers;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class UserActions
    {
        protected static Users CreateUser(Users body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.CreateUser);
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePostRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            Log.Information(JToken.Parse(request.Body.Value.ToString()!).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Users>(response);
        }

        public string LogIn(string userName, string password, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.LogInUser);
            var request = rawRequest.PrepareGetRequest();
            request.AddQueryParameter("username",userName);
            request.AddQueryParameter("password", password);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            Log.Information(response.Content);
            return response.Content;
        }

        public string LogOut(HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.LogOutUser);
            var request = rawRequest.PrepareGetRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            Log.Information(response.Content);
            return response.Content;
        }

        public Users GetUserByUsername(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.GetUserByUsername);
            var request = rawRequest.PrepareGetRequest();
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Users>(response);
        }

        public Users UpdateUser(Users body, string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.GetUserByUsername);
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePutRequest(jsonBody);
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Users>(response);
        }

        public string DeleteUser(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl(PetStoreUrls.GetUserByUsername);
            var request = rawRequest.PrepareDeleteRequest();
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            Log.Information(response.Content);
            return response.Content;
        }
    }
}