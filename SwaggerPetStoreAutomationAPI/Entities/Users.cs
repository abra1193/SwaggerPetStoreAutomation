﻿using Newtonsoft.Json;

namespace SwaggerPetStoreAutomationAPI.Entities
{
    public partial class Users
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty("firstName", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty("password", Required = Required.Always)]
        public string Password { get; set; }

        [JsonProperty("phone", Required = Required.Always)]
        public string Phone { get; set; }

        [JsonProperty("userStatus", Required = Required.Always)]
        public int UserStatus { get; set; }
    }
}
