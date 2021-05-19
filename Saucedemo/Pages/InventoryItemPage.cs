using System;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;

namespace Saucedemo.Pages
{
    public class InventoryItemPage : BasePage
    {
        private static string END_POINT = "inventory-item.html";
        
        private static readonly By ItemNameBy = By.ClassName("inventory_details_name large_size");
        private static readonly By ItemDescription = By.ClassName("inventory_details_desc large_size");
        private static readonly By PriceBy = By.ClassName("inventory_details_price");
        private static readonly By ImageBy = By.ClassName("inventory_details_img");
        
        public InventoryItemPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        public InventoryItemPage(IWebDriver driver) : base(driver, false)
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
                return Image.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*public void AddToCart()
        {
            var addToCart = new Button(Driver, By.XPath("//button[contains(@id, 'add-to-cart')]"));
            if (addToCart.Text().Equals("Add to cart"))
            {
                addToCart.Click();
            }

            throw new Exception("This item has already been added to cart.");
        }
        
        public void RemoveFromCart()
        {
            var removeFromCart = new Button(Driver, By.XPath("//button[contains(@id, 'remove')]"));
            if (removeFromCart.Text().Equals("Remove"))
            {
                removeFromCart.Click();
            }

            throw new Exception("This item has already been removed from cart.");
        }*/
        
        public IWebElement Image => _wait.GetVisibleElement(ImageBy);
        public Button Button => new Button(Driver, By.CssSelector("button.btn_inventory"));
 
    }
}