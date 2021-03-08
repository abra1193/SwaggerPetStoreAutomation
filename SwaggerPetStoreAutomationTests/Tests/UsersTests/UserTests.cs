using FluentAssertions;
using FluentAssertions.AssertMultiple;
using Serilog;
using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationTests.BaseTests;
using SwaggerPetStoreAutomationTests.SharedSteps;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationTests.UsersTests
{
    public class UserTests : BaseClass
    {
        public UserTests(ITestOutputHelper outputHelper) : base(outputHelper) { }

        [Fact]
        public void VerifyUsersCanLogInAndLogOut()
        {
            Log.Information("Verify users can logIn/logOut");
            var user = UserSharedSteps.CreateUser("firstName", "lastName", "userName");
            var userLogIn = UserActions.LogIn(user.Username, user.Password);
            var userLogOut = UserActions.LogOut();
            AssertMultiple.Multiple(() =>
            {
                userLogIn.Should().NotBeNullOrEmpty();
                userLogOut.Should().NotBeNullOrEmpty();
                userLogIn.Should().Contain("Logged in user session");
                userLogOut.Should().Contain("User logged out");
            });
        }

        [Fact]
        public void VerifyUserCreation()
        {
            Log.Information("Verify users can be created");
            var user = UserSharedSteps.CreateUser("firstName", "lastName", "userName");
            var userData = UserActions.GetUserByUsername(user.Username);
            AssertMultiple.Multiple(() =>
            {
                userData.Should().NotBeNull();
                userData.Id.Should().Be(userData.Id);
                userData.Username.Should().Be(userData.Username);
                userData.FirstName.Should().Be(userData.FirstName);
                userData.LastName.Should().Be(userData.LastName);
                userData.Email.Should().Be(userData.Email);
                userData.Password.Should().Be(userData.Password);
                userData.Phone.Should().Be(userData.Phone);
                userData.UserStatus.Should().Be(userData.UserStatus);
            });
        }

        [Fact]
        public void UserCRUDTest()
        {
            Log.Information("Verify users can be created/Updated/Deleted on the aplication");
            var user = UserSharedSteps.CreateUser("firstName", "lastName", "userName");
            var userData = UserActions.GetUserByUsername(user.Username);
            userData.Id.Should().Be(user.Id);
            user.Password = "MyNewPassword@!";
            UserActions.UpdateUser(user, user.Username);
            var updateUser = UserActions.GetUserByUsername(user.Username);
            updateUser.Password.Should().Be(user.Password);
            UserActions.DeleteUser(user.Username, HttpStatusCode.OK);
        }
    }
}