using System.Net;
using FluentAssertions;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationAPI.Entities;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class UserActions
    {
        public static Users CreateUser(Users body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl("user");
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Users>(response);
        }

        public static string LogIn(string userName, string password, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl($"user/login?username={userName}&password={password}");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return response.Content;
        }

        public static string LogOut(HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl("user/logout");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return response.Content;
        }

        public static Users GetUserByUsername(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl($"user/{userName}");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Users>(response);
        }

        public static Users UpdateUser(Users body, string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl($"user/{userName}");
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePUTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Users>(response);
        }

        public static string DeleteUser(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Users>();
            var url = rawRequest.SetUrl($"user/{userName}");
            var request = rawRequest.PrepareDELETERequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return response.Content;
        }
    }
}