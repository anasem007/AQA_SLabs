using OpenQA.Selenium;

namespace Saucedemo.Core.Wrappers
{
    public class ListItem
    {
        private readonly UiElement _uiElement;
        private readonly IWebDriver _driver;
        
        public ListItem(IWebDriver driver, By @by)
        {
            _uiElement = new UiElement(driver, @by);
            _driver = driver;
        }
        
        public ListItem(IWebDriver driver, IWebElement webElement)
        {
            _uiElement = new UiElement(driver, webElement);
            _driver = driver;
        }

        public Button Name => new Button(_driver, _uiElement.FindElement(By.XPath(".//div[contains(@class, 'item_name')]")));
        public string Price =>_uiElement.FindElement(By.XPath(".//div[contains(@class, 'item_price')]")).Text;
        public string Description => _uiElement
            .FindElement(By.XPath(".//div[contains(@class, '_item_label')]//div[contains(@class, '_item_desc')]")).Text;
        public Button Button => new Button(_driver, _uiElement.FindElement(By.XPath(".//button")));
    }
}