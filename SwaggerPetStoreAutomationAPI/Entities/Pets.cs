using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwaggerPetstoreAutomation
{
    public partial class Pets
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("name", Required = Required.Default)]
        public string Name { get; set; }

        [JsonProperty("category", Required = Required.Default)]
        public Category Category { get; set; }

        [JsonProperty("photoUrls", Required = Required.Default)]
        public List<string> PhotoUrls { get; set; }

        [JsonProperty("tags", Required = Required.Default)]
        public List<Category> Tags { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }

    public enum PetStatus
    {
        available,
        pending,
        sold
    }
}