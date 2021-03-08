using SwaggerPetstoreAutomation;
using System;
using System.Collections.Generic;

namespace SwaggerPetStoreAutomationTests
{
    public class PetsSharedSteps
    {
        public static Pets InitializePet(string name, PetStatus petStatus)
        {
            var random = new Random();
            return new Pets()
            {
                Id = random.Next(1, 100),
                Name = name,
                Status = petStatus.ToString(),
                Category = new Category()
                {
                    Id = random.Next(1, 100),
                    Name = "Test Category Name"
                }
            };
        }

        public static Pets CreatePet(string name, PetStatus petStatus, Pets pet = null)
        {
            var petToCreate = pet;
            if (petToCreate == null) petToCreate = InitializePet(name, petStatus);
            return PetsActions.AddNewPetToStore(petToCreate);
        }
    }
}
