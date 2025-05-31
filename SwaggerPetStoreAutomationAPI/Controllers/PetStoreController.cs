using System.IO;
using Newtonsoft.Json;
using RestSharp;

namespace SwaggerPetStoreAutomationAPI.Controllers
{
    public class PetStoreController<T>
    {
        public RestClient RestClient;
        public RestRequest RestRequest;

        private const string BaseUrl = "https://petstore3.swagger.io/api/v3/";

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(BaseUrl, endpoint);
            var restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest PrepareGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest PreparePostRequest(dynamic requestBody)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest PreparePutRequest(string requestBody)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest PrepareDeleteRequest()
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public TEntities GetResponseContent<TEntities>(IRestResponse response)
        {
            var content = response.Content;
            var entitiesObject = JsonConvert.DeserializeObject<TEntities>(content);
            return entitiesObject;
        }
    }
}