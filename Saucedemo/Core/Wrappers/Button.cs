using OpenQA.Selenium;

namespace Saucedemo.Core.Wrappers
{
    public class Button
    {
        private readonly UiElement _uiElement;
        
        public Button(IWebDriver driver, By @by)
        {
            _uiElement = new UiElement(driver, @by);
        }
        
        public Button(IWebDriver driver, IWebElement webElement)
        {
            _uiElement = new UiElement(driver, webElement);
        }

        public void Click() => _uiElement.Click();
        public string Text() => _uiElement.Text;
        public bool Enabled => _uiElement.Enabled;
        public bool Displayed => _uiElement.Displayed;

    }
}