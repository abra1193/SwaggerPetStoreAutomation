using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Entities;
using System;

namespace SwaggerPetStoreAutomationTests.SharedSteps
{
    public class UserSharedSteps
    {

        public static Users InitializeUser(string firstName, string lastName, string userName)
        {
            var random = new Random();
            return new Users()
            {
                Id = random.Next(1, 100),
                FirstName = firstName,
                LastName = lastName,
                Username = userName,
                Email = "test@testemail.com",
                Password = "123456789@!",
                Phone = "1234567890",
                UserStatus = 1
            };
        }

        public static Users CreateUser(string firstName, string lastName, string userName,Users user = null)
        {
            var userToCreate = user;
            if (userToCreate == null) userToCreate = InitializeUser(firstName, lastName, userName);
            return UserActions.CreateUser(userToCreate);
        }
    }
}
