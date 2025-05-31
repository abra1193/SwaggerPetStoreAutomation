using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationAPI.Helpers;

namespace SwaggerPetStoreAutomationTests.TestsSharedSteps
{
    public class UserSharedSteps : UserActions
    {
        private static Users InitializeUser(string firstName, string lastName, string userName)
        {
            return new Users()
            {
                Id = int.Parse(Randomizer.GenerateRandomId()),
                FirstName = firstName,
                LastName = lastName,
                Username = userName,
                Email = Randomizer.GenerateRandomEmail(),
                Password = Randomizer.GenerateRandomString(),
                Phone = Randomizer.GenerateRandomPhoneNumber(),
                UserStatus = 1
            };
        }

        public Users CreateUser(string firstName, string lastName, string userName,Users user = null)
        {
            var userToCreate = user;
            if (userToCreate == null) userToCreate = InitializeUser(firstName, lastName, userName);
            return CreateUser(userToCreate);
        }
    }
}
