using System;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;

namespace Saucedemo.Pages
{
    public class CartPage : BasePage
    {
        private static string END_POINT = "cart.html";

        private static readonly By ItemsListBy = By.ClassName("cart_list");
        private static readonly By ContinueShoppingButtonBy = By.Id("continue-shopping");
        private static readonly By CheckoutButtonBy = By.Id("checkout");

        public CartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CartPage(IWebDriver driver) : base(driver, false)
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
                return Checkout.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public ItemsList ItemsList => new ItemsList(Driver, ItemsListBy, "cart_item");
        public Button ContinueShopping => new Button(Driver, ContinueShoppingButtonBy);
        public Button Checkout => new Button(Driver, CheckoutButtonBy);
    }
}