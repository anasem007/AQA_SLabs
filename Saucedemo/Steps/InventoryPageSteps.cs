using System.Collections.Generic;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;
using Saucedemo.Pages;

namespace Saucedemo.Steps
{
    public class InventoryPageSteps : BaseSteps
    {
        private readonly InventoryPage _inventoryPage;
        
        public InventoryPageSteps(IWebDriver driver) : base(driver)
        {
            _inventoryPage = new InventoryPage(Driver, true);
        }

        public bool IsPageOpened()
        {
            return _inventoryPage.IsPageOpened();
        }

        public string GetPageTitle()
        {
            return _inventoryPage.Title;
        }
        
        public ListItem AddItemToCart(string name)
        {
            var item = _inventoryPage.ItemsList.SelectItemByName(name);
            item.Button.Click();

            return item;
        }
        
        public void SelectOption(string option)
        {
            _inventoryPage.ProductSort.SelectByValue(option);
        }

        public void GoToCart()
        {
            _inventoryPage.GoToCart.Click();
        }

        public List<ListItem> GetItems()
        {
            return _inventoryPage.ItemsList.GetAllItems();
        }

        public string GetItemButtonName(string itemName)
        {
            return _inventoryPage
                        .ItemsList
                        .SelectItemByName(itemName)
                        .Button
                        .Text();
        }

        public string GetCartBadgeText()
        {
            return _inventoryPage.GoToCart.Text();
        }

        public List<string> GetAllItemsPrices()
        {
            return _inventoryPage.ItemsList.ItemsPrices;
        }

        public List<string> GetAllItemsNames()
        {
            return _inventoryPage.ItemsList.ItemsNames;
        }
    }
}