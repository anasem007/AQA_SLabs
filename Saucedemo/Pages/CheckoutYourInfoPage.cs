using System;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;

namespace Saucedemo.Pages
{
    public class CheckoutYourInfoPage : BasePage
    {
        private static string END_POINT = "checkout-step-one.html";

        private static readonly By TitleBy = By.ClassName("title");
        private static readonly By FirstNameInputBy = By.Id("first-name");
        private static readonly By LastNameInputBy = By.Id("last-name");
        private static readonly By ZipCodeInputBy = By.Id("postal-code");
        private static readonly By CancelButtonBy = By.Id("cancel");
        private static readonly By ContinueButtonBy = By.Id("continue");
        private static readonly By ErrorBy = By.ClassName("error-message-container error");

        public CheckoutYourInfoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
                return Continue.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Title = Driver.FindElement(TitleBy).Text;
        public Input FirstName = new Input(Driver, FirstNameInputBy);
        public Input LastName = new Input(Driver, LastNameInputBy);
        public Input ZipCode = new Input(Driver, ZipCodeInputBy);
        public Button Cancel = new Button(Driver, CancelButtonBy);
        public Button Continue = new Button(Driver, ContinueButtonBy);
        public Error Error = new Error(Driver, ErrorBy);
    }
}