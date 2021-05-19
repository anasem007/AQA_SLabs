using System;
using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Core.Wrappers;

namespace Saucedemo.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
        
        private static readonly By UsernameInputBy = By.Id("user-name");
        private static readonly By PasswordInputBy = By.Id("password");
        private static readonly By LogInButtonBy = By.Id("login-button");
        private static readonly By ErrorBy = By.CssSelector("div.error-message-container.error");
        
        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        public LoginPage(IWebDriver driver) : base(driver, false)
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
                return Login.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public Input Username => new Input(Driver, UsernameInputBy);
        public Input Password => new Input(Driver, PasswordInputBy);
        public Button Login => new Button(Driver, _wait.GetVisibleElement(LogInButtonBy));
        public Error Error => new Error(Driver, _wait.GetVisibleElement(ErrorBy));
    }
}