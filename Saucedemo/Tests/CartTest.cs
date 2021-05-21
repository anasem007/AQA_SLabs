using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;
using Saucedemo.Models;
using Saucedemo.Services;
using Saucedemo.Steps;

namespace Saucedemo.Tests
{
    public class CartTest : BaseTest
    {
        private CartPageSteps _cartPageSteps;
        private InventoryPageSteps _inventoryPageSteps;
        
        [SetUp]
        public void SetUp()
        {
            var user = new User
            {
                Username = Configurator.Username,
                Password = Configurator.Password
            };
            
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login(user);

            _inventoryPageSteps = new InventoryPageSteps(Driver);
        }

        [Test]
        public void CartPage_NoAddingItemsToCart_CartIsEmpty()
        {
            _inventoryPageSteps.GoToCart();
            
            _cartPageSteps = new CartPageSteps(Driver);
            _cartPageSteps.GetItemsCount().Should().Be(0);
        }
    }
}