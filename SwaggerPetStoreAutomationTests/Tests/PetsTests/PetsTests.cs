using FluentAssertions;
using FluentAssertions.AssertMultiple;
using SwaggerPetstoreAutomation;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SwaggerPetStoreAutomationTests.PetsTests
{
    public class PetsTests
    {

        [Fact]
        public void PetsCRUDTest()
        {
            var newPetAdded = PetsSharedSteps.CreatePet("Cookie", PetStatus.available);
            var newPetData = PetsActions.FindPetById(newPetAdded.Id);
            newPetAdded.Name = "My Sweet Cookie";
            var updatePetData = PetsActions.UpdateAnExistingPet(newPetAdded);
            var updatePet = PetsActions.FindPetById(newPetAdded.Id);
            updatePet.Name.Should().Be(updatePetData.Name);
            var deletedPetMessage = PetsActions.DeleteAPet(newPetAdded.Id);
            AssertMultiple.Multiple(() =>
            {
                newPetData.Id.Should().Be(newPetAdded.Id);
                newPetData.Status.Should().Be(PetStatus.available.ToString());
                deletedPetMessage.Should().NotBeNullOrEmpty();
                deletedPetMessage.Should().Be("Pet deleted");

            });
        }

        [Fact]
        public void VerifyFindPetByStatus()
        {
            var responseAvailable = PetsActions.FindPetByStatus(PetStatus.available);
            var responsePending = PetsActions.FindPetByStatus(PetStatus.pending);
            var responseSold = PetsActions.FindPetByStatus(PetStatus.sold);
            AssertMultiple.Multiple(() =>
            {
                responseAvailable.Should().HaveCountGreaterThan(0);
                responsePending.Should().HaveCountGreaterThan(0);
                responseSold.Should().HaveCountGreaterThan(0);
                responseAvailable.ForEach(x => x.Status.Should().Be(PetStatus.available.ToString()));
                responsePending.ForEach(x => x.Status.Should().Be(PetStatus.pending.ToString()));
                responseSold.ForEach(x => x.Status.Should().Be(PetStatus.sold.ToString()));
            });
        }

        [Fact]
        public void VerifyFindPetByTags()
        {
            var petTag = "tag1";
            var response = PetsActions.FindPetByTags(petTag);
            AssertMultiple.Multiple(() =>
            {
                response.Should().HaveCountGreaterThan(0);
                response[0].Tags[0].Name.Should().Be(petTag);
            });
        }

        [Fact]
        public void VerifyUploadAnImageToAPet()
        {
            var newPet = PetsSharedSteps.InitializePet("Cake", PetStatus.available);
            newPet.PhotoUrls = new List<string> { };
            PetsActions.AddNewPetToStore(newPet);
            var file = File.ReadAllBytes("Resources\\UploadPhoto.png");
            var response = PetsActions.UploadAnImageToAPet(newPet.Id, file);
            response.PhotoUrls[0].Should().NotBeNullOrEmpty();
        }
    }
}