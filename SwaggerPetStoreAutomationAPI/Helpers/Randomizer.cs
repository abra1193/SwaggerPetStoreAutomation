using System;
using System.Linq;

namespace SwaggerPetStoreAutomationAPI.Helpers
{
    public static class Randomizer
    {
        private const string NUMERIC_CHARACTERS = "0123456789";
        private const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        private const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static readonly Random _random = new Random();

        public static string GenerateRandomString(int lenght = 8)
        {
            const string chars = LOWERCASE_CHARACTERS + UPPERCASE_CHARACTERS;
            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomId(int lenght = 2)
        {
            const string chars = NUMERIC_CHARACTERS;
            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomPhoneNumber(int lenght = 8)
        {
            const string chars = NUMERIC_CHARACTERS;
            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomEmail(string domain = "@testemail.com")
        {
            var username = GenerateRandomString();
            return username + domain;
        }
    }
}