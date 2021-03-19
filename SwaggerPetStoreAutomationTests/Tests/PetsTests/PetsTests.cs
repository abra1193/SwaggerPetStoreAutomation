using FluentAssertions;
using FluentAssertions.AssertMultiple;
using Serilog;
using SwaggerPetstoreAutomation;
using SwaggerPetStoreAutomationTests.BaseTests;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationTests.PetsTests
{
    public class PetsTests : BaseClass
    {
        public PetsTests(ITestOutputHelper outputHelper) : base(outputHelper) { }

        [Fact]
        public void PetsCRUDTest()
        {
            Log.Information("Verify pets can be created/Updated/Deleted");
            var newPetAdded = SharedSteps.PetsSharedSteps.CreatePet("Cookie", PetStatus.available);
            var newPetData = Actions.PetsActions.FindPetById(newPetAdded.Id);
            newPetAdded.Name = "My Sweet Cookie";
            var updatePetData = Actions.PetsActions.UpdateAnExistingPet(newPetAdded);
            var updatePet = Actions.PetsActions.FindPetById(newPetAdded.Id);
            updatePet.Name.Should().Be(updatePetData.Name);
            var deletedPetMessage = Actions.PetsActions.DeleteAPet(newPetAdded.Id);
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
            Log.Information("Verify pets can be search by status(available,pending and sold)");
            var responseAvailable = Actions.PetsActions.FindPetByStatus(PetStatus.available);
            var responsePending = Actions.PetsActions.FindPetByStatus(PetStatus.pending);
            var responseSold = Actions.PetsActions.FindPetByStatus(PetStatus.sold);
            AssertMultiple.Multiple(() =>
            {
                responseAvailable.Should().HaveCountGreaterOrEqualTo(0);
                responsePending.Should().HaveCountGreaterOrEqualTo(0);
                responseSold.Should().HaveCountGreaterOrEqualTo(0);
                responseAvailable.ForEach(x => x.Status.Should().Be(PetStatus.available.ToString()));
                responsePending.ForEach(x => x.Status.Should().Be(PetStatus.pending.ToString()));
                responseSold.ForEach(x => x.Status.Should().Be(PetStatus.sold.ToString()));
            });
        }

        [Fact]
        public void VerifyFindPetByTags()
        {
            Log.Information("Verify pets can be search by different tags");
            var petTag = "tag1";
            var response = Actions.PetsActions.FindPetByTags(petTag);
            AssertMultiple.Multiple(() =>
            {
                response.Should().HaveCountGreaterThan(0);
                response[0].Tags[0].Name.Should().Be(petTag);
            });
        }

        [Fact]
        public void VerifyUploadAnImageToAPet()
        {
            Log.Information("Verify images can be uploaded to pet entities");
            var newPet = SharedSteps.PetsSharedSteps.InitializePet("Cake", PetStatus.available);
            newPet.PhotoUrls = new List<string> { };
            Actions.PetsActions.AddNewPetToStore(newPet);
            var file = File.ReadAllBytes("Resources//UploadPhoto.png");
            var response = Actions.PetsActions.UploadAnImageToAPet(newPet.Id, file);
            response.PhotoUrls[0].Should().NotBeNullOrEmpty();
        }
    }
}