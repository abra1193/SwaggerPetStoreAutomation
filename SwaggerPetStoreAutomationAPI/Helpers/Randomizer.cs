using System;
using System.Linq;

namespace SwaggerPetStoreAutomationAPI.Helpers
{
    public static class Randomizer
    {
        private const string NumericCharacters = "0123456789";
        private const string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static readonly Random Random = new Random();

        public static string GenerateRandomString(int lenght = 8)
        {
            const string chars = LowercaseCharacters + UppercaseCharacters;
            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomId(int lenght = 2)
        {
            const string chars = NumericCharacters;
            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomPhoneNumber(int lenght = 8)
        {
            const string chars = NumericCharacters;
            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomEmail(string domain = "@testemail.com")
        {
            var username = GenerateRandomString();
            return username + domain;
        }
    }
}