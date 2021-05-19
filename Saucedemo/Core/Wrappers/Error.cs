using OpenQA.Selenium;

namespace Saucedemo.Core.Wrappers
{
    public class Error
    {
        private readonly UiElement _uiElement;
        private readonly IWebDriver _driver;

        public Error(IWebDriver driver, By by)
        {
            _driver = driver;
            _uiElement = new UiElement(driver, by);
        }

        public Error(IWebDriver driver, IWebElement webElement)
        {
            _uiElement = new UiElement(driver, webElement);
        }

        public string Message => _uiElement.FindElement(By.XPath(".//h3")).Text;

        public Button Close => new Button(_driver, _uiElement.FindElement(By.ClassName("error-button")));
    }
}