using System.IO;
using Newtonsoft.Json;

namespace SwaggerPetStoreAutomationAPI.Handlers
{
    public static class JsonHandler
    {
        public static string Serialize<T>(T body)
        {
            return JsonConvert.SerializeObject(body,Formatting.Indented);
        }

        public static T ParseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}