using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationAPI.Helpers;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class PetsActions
    {
        public Pets FindPetById(int petId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl(PetStoreUrls.FindPetById);
            var request = rawRequest.PrepareGETRequest();
            request.AddUrlSegment("petId", petId);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Pets>(response);
        }

        public Pets AddNewPetToStore(Pets body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl(PetStoreUrls.AddNewPetToStore);
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            if (request.Body != null) Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Pets>(response);
        }

        public Pets UpdateAnExistingPet(Pets body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl(PetStoreUrls.AddNewPetToStore);
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePUTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Body--------------------------");
            if (request.Body != null) Log.Information(JToken.Parse(request.Body.Value.ToString()).ToString(Formatting.Indented));
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Pets>(response);
        }

        public string DeleteAPet(int petId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl(PetStoreUrls.FindPetById);
            var request = rawRequest.PrepareDELETERequest();
            request.AddUrlSegment("petId", petId);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(response.Content);
            return response.Content;
        }

        public List<Pets> FindPetByStatus(PetStatus petStatus, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl(PetStoreUrls.FindPetByStatus);
            var request = rawRequest.PrepareGETRequest();
            request.AddQueryParameter("status", petStatus.ToString());
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<List<Pets>>(response);
        }

        public List<Pets> FindPetByTags(string petTags, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl(PetStoreUrls.FindPetByTags);
            var request = rawRequest.PrepareGETRequest();
            request.AddQueryParameter("tags", petTags.ToString());
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<List<Pets>>(response);
        }

        public Pets UploadAnImageToAPet(int petId, byte[] file, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl(PetStoreUrls.UploadAnImageToAPet);
            var request = rawRequest.PreparePOSTRequest(file);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddUrlSegment("petId", petId);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            Log.Information(request.Method.ToString() + " " + response.ResponseUri.OriginalString);
            Log.Information("-------------------------------Response--------------------------");
            if (response.Content != null) Log.Information(JToken.Parse(response.Content).ToString(Formatting.Indented));
            return rawRequest.GetResponseContent<Pets>(response);
        }
    }
}