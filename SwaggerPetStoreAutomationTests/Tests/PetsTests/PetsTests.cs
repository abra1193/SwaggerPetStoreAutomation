using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using FluentAssertions.AssertMultiple;
using Serilog;
using SwaggerPetStoreAutomationAPI.Entities;
using SwaggerPetStoreAutomationTests.BaseTests;
using Xunit;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationTests.Tests.PetsTests
{
    public class PetsTests : BaseClass
    {
        public PetsTests(ITestOutputHelper outputHelper) : base(outputHelper) { }

        [Fact]
        public void PetsCrudTest()
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
                newPetData.Status.Should().Be(nameof(PetStatus.available));
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
                responseAvailable.Should().HaveCountGreaterThan(0);
                responsePending.Should().HaveCountGreaterThan(0);
                responseSold.Should().HaveCountGreaterThan(0);
                responseAvailable.ForEach(x => x.Status.Should().Be(nameof(PetStatus.available)));
                responsePending.ForEach(x => x.Status.Should().Be(nameof(PetStatus.pending)));
                responseSold.ForEach(x => x.Status.Should().Be(nameof(PetStatus.sold)));
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
            newPet.PhotoUrls = new List<string>();
            Actions.PetsActions.AddNewPetToStore(newPet);
            var file = File.ReadAllBytes("Resources//UploadPhoto.png");
            var response = Actions.PetsActions.UploadAnImageToAPet(newPet.Id, file);
            response.PhotoUrls[0].Should().NotBeNullOrEmpty();
        }
    }
}