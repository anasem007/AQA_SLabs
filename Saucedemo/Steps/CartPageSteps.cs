using System.Collections.Generic;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;
using Saucedemo.Pages;

namespace Saucedemo.Steps
{
    public class CartPageSteps : BaseSteps
    {
        private readonly CartPage _cartPage;
        
        public CartPageSteps(IWebDriver driver) : base(driver)
        {
            _cartPage = new CartPage(driver, true);
        }

        public List<ListItem> GetItems()
        {
            return _cartPage.ItemsList.GetAllItems();
        }

        public int GetItemsCount()
        {
            return _cartPage.ItemsList.ItemsCount;
        }
    }
}