using System;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;

namespace Saucedemo.Pages
{
    public class InventoryPage : BasePage
    {
        private static string END_POINT = "inventory.html";

        private static readonly By TitleBy = By.ClassName("title");
        private static readonly By ProductSortBy = By.ClassName("product_sort_container");
        private static readonly By ItemsListBy = By.CssSelector(".inventory_list");
        private static readonly By GoToCartButtonBy = By.ClassName("shopping_cart_link");

        public InventoryPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public InventoryPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return GoToCart.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ItemsList ItemsList => new ItemsList(Driver, ItemsListBy, "inventory_item");
        public DropDownMenu ProductSort => new DropDownMenu(Driver, ProductSortBy);
        public Button GoToCart => new Button(Driver, GoToCartButtonBy);
        public string Title => Driver.FindElement(TitleBy).Text;
    }
}