using OpenQA.Selenium;

namespace Saucedemo.Core.Wrappers
{
    public class Info
    {
        private readonly UiElement _uiElement;

        private static readonly By ItemTotalBy = By.ClassName("summary_subtotal_label");
        private static readonly By TaxBy = By.ClassName("summary_tax_label");
        private static readonly By TotalBy = By.ClassName("summary_total_label");

        
        public Info(IWebDriver driver, By by)
        {
            _uiElement = new UiElement(driver, by);
        }

        public Info(IWebDriver driver, IWebElement webElement)
        {
            _uiElement = new UiElement(driver, webElement);
        }

        public string ItemTotal => _uiElement.FindElement(ItemTotalBy).Text;        
        public string Tax => _uiElement.FindElement(TaxBy).Text;
        public string Total => _uiElement.FindElement(TotalBy).Text;
    }
}