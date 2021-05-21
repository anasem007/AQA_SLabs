using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using Saucedemo.BaseEntities;
using Saucedemo.Services;
using Saucedemo.Steps;

namespace Saucedemo.Tests
{
    public class LoginPageTest : BaseTest
    {
        private LoginSteps _loginSteps;

        [SetUp]
        public void SetUp()
        {
            _loginSteps = new LoginSteps(Driver);
        }
        
        [Test]
        public void LoginPage_StandardUserLogin()
        {
            _loginSteps.Login(User);
            
            var inventoryPageSteps = new InventoryPageSteps(Driver);

            using (new AssertionScope())
            {
                inventoryPageSteps.IsPageOpened().Should().BeTrue();
                inventoryPageSteps.GetPageTitle().Should().Be("PRODUCTS");
            }
        }
        
        [Test]
        public void LoginPage_LockedOutUserLogin()
        {
            var user = UserService.GetUser("locked_out_user");
            
            _loginSteps.Login(user);
            
            _loginSteps.GetErrorMessage().Should().Be("Epic sadface: Sorry, this user has been locked out.");
        }
        

        [Test]
        public void LoginPage_FakeUserLogin()
        {
            var user = UserService.GetUser("fake_user");
            
            _loginSteps.Login(user);

            _loginSteps.GetErrorMessage().Should().Be("Epic sadface: Username and password do not match any user in this service");
        }
    }
}