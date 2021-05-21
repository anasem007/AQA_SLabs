using System;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;
using Saucedemo.Services;

namespace Saucedemo.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private static string END_POINT = "checkout-complete.html";
        
        private static readonly By TitleBy = By.ClassName("title");
        private static readonly By BackHomeButtonBy = By.Id("back-to-products");
        private static readonly By MessageTitleBy = By.ClassName("complete-header");
        private static readonly By MessageTextBy = By.ClassName("complete-text");

        public CheckoutCompletePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
               return BackHome.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public string Title = Driver.FindElement(TitleBy).Text;
        public Button BackHome = new Button(Driver, BackHomeButtonBy);
        public string MessageTitle = Driver.FindElement(MessageTitleBy).Text;
        public string MessageText = Driver.FindElement(MessageTextBy).Text;

    }
}