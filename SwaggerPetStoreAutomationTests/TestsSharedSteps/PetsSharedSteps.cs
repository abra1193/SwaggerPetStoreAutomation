using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationAPI.Helpers;

namespace SwaggerPetStoreAutomationTests.TestsSharedSteps
{
    public class PetsSharedSteps : PetsActions
    {

        public Pets InitializePet(string name, PetStatus petStatus)
        {
            return new Pets()
            {
                Id = int.Parse(Randomizer.GenerateRandomId()),
                Name = name,
                Status = petStatus.ToString(),
                Category = new Category()
                {
                    Id = int.Parse(Randomizer.GenerateRandomId()),
                    Name = Randomizer.GenerateRandomString()
                }
            };
        }

        public Pets CreatePet(string name, PetStatus petStatus, Pets pet = null)
        {
            var petToCreate = pet;
            if (petToCreate == null) petToCreate = InitializePet(name, petStatus);
            return AddNewPetToStore(petToCreate);
        }
    }
}