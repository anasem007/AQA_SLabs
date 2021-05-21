using OpenQA.Selenium;
using Saucedemo.BaseEntities;
using Saucedemo.Models;
using Saucedemo.Pages;

namespace Saucedemo.Steps
{
    public class LoginSteps : BaseSteps
    {
        private readonly LoginPage _loginPage;
        public LoginSteps(IWebDriver driver) : base(driver)
        {
            _loginPage = new LoginPage(driver, true);
        }
        
        public void Login(User user)
        {
            _loginPage.Username.SendKeys(user.Username);
            _loginPage.Password.SendKeys(user.Password);
            _loginPage.Login.Click();
        }

        public string GetErrorMessage()
        {
            return _loginPage.Error.Message;
        }
    }
}