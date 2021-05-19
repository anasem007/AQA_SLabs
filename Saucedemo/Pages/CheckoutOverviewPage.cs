using System;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;

namespace Saucedemo.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private static string END_POINT = "checkout-step-two.html";

        private static readonly By TitleBy = By.ClassName("title");
        private static readonly By CancelButtonBy = By.Id("cancel");
        private static readonly By FinishButtonBy = By.Id("finish");
        private static readonly By ItemsListBy = By.ClassName("cart_list");
        private static readonly By OrderInfoBy = By.ClassName("summary_info");

        public CheckoutOverviewPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutOverviewPage(IWebDriver driver) : base(driver, false)
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
                return Finish.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Title = Driver.FindElement(TitleBy).Text;
        public Button Cancel = new Button(Driver, CancelButtonBy);
        public Button Finish = new Button(Driver, FinishButtonBy);
        public ItemsList ItemsList => new ItemsList(Driver, ItemsListBy, "cart_item");
        public Info OrderInfo => new Info(Driver, OrderInfoBy);

    }
}