﻿using System.Collections.Generic;
using System.Linq;
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
    public class InventoryPageTest : BaseTest
    {
        private InventoryPageSteps _inventoryPageSteps;       
        private CartPageSteps _cartPageSteps;

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
        public void InventoryPage_AddItemToCart()
        {
            var itemName = _inventoryPageSteps.AddItemToCart("Sauce Labs Onesie").Name.Text();
            
            using (new AssertionScope())
            {
                _inventoryPageSteps.GetItemButtonName("Sauce Labs Onesie").Should().Be("REMOVE");
                _inventoryPageSteps.GetCartBadgeText().Should().Be(1.ToString());
                _cartPageSteps = new CartPageSteps(Driver);
                 _cartPageSteps.GetItemsCount().Should().Be(1);
                 _cartPageSteps.GetItems().Select(i => i.Name.Text()).Should().Equal(itemName);
            }
        }

        [Test]
        public void InventoryPage_AddMoreThanOneItemToCart()
        {
            var listItemOne = _inventoryPageSteps.AddItemToCart("Sauce Labs Onesie");
            var listItemTwo = _inventoryPageSteps.AddItemToCart("Sauce Labs Backpack");
            
            var expectedItemsInCart = new List<ListItem> {listItemOne, listItemTwo};
            
            using (new AssertionScope())
            {
                _inventoryPageSteps.GetItemButtonName("Sauce Labs Onesie").Should().Be("REMOVE");
                _inventoryPageSteps.GetItemButtonName("Sauce Labs Backpack").Should().Be("REMOVE");
                _inventoryPageSteps.GetCartBadgeText().Should().Be(2.ToString());
                _cartPageSteps = new CartPageSteps(Driver);
                _cartPageSteps.GetItemsCount().Should().Be(2);

            }
        }
    }
}