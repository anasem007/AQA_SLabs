using FluentAssertions;
using NUnit.Framework;
using Saucedemo.BaseEntities;
using Saucedemo.Steps;
using saucedemo.Utils;

namespace Saucedemo.Tests
{
    public class ProductSortTest : BaseTest
    {
        private InventoryPageSteps _inventoryPageSteps;

        [SetUp]
        public new void Setup()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login(User);
            
            _inventoryPageSteps = new InventoryPageSteps(Driver);
        }

        [Test]
        public void SortNamesInAscendingOrder()
        {
            _inventoryPageSteps.SelectOption("az");
            
            var namesList = _inventoryPageSteps.GetAllItemsNames();
          
            namesList.Should().BeInAscendingOrder();
        }
        
        [Test]
        public void SortNames()
        {
            _inventoryPageSteps.SelectOption("za");
            
            var namesList = _inventoryPageSteps.GetAllItemsNames();
          
            namesList.Should().BeInDescendingOrder();
        }
        
        [Test]
        public void SortPricesInAscendingOrder()
        {
            _inventoryPageSteps.SelectOption("lohi"); 
            
            var prices = Converter.FromStringToDouble(_inventoryPageSteps.GetAllItemsPrices());
            
            prices.Should().BeInAscendingOrder();
        }
        
        [Test]
        public void SortPricesInDescendingOrder()
        {
            _inventoryPageSteps.SelectOption("hilo"); 
            
            var prices = Converter.FromStringToDouble(_inventoryPageSteps.GetAllItemsPrices());
            
            prices.Should().BeInDescendingOrder();
        }
    }
}