using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using SwaggerPetstoreAutomation;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class PetsActions
    {
        public Pets FindPetById(int petId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl($"pet/{petId}");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Pets>(response);
        }

        public Pets AddNewPetToStore(Pets body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl("pet");
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Pets>(response);
        }

        public Pets UpdateAnExistingPet(Pets body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl("pet");
            var jsonBody = JsonHandler.Serialize(body);
            var request = rawRequest.PreparePUTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Pets>(response);
        }

        public string DeleteAPet(int petId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl($"pet/{petId}");
            var request = rawRequest.PrepareDELETERequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return response.Content;
        }

        public List<Pets> FindPetByStatus(PetStatus petStatus, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl($"pet/findByStatus?status={petStatus}");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<List<Pets>>(response);
        }

        public List<Pets> FindPetByTags(string petTags, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl($"pet/findByTags?tags={petTags}");
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<List<Pets>>(response);
        }

        public Pets UploadAnImageToAPet(int petId, byte[] file, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var rawRequest = new PetStoreController<Pets>();
            var url = rawRequest.SetUrl($"pet/{petId}/uploadImage");
            var request = rawRequest.PreparePOSTRequest(file);
            request.AddHeader("Content-Type", "application/octet-stream");
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Should().Be(expectedStatusCode);
            return rawRequest.GetResponseContent<Pets>(response);
        }
    }
}