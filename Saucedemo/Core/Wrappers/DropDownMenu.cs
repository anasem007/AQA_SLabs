using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Saucedemo.Core.Wrappers
{
    public class DropDownMenu
    {
        private readonly SelectElement _uiElement;

        public DropDownMenu(IWebDriver driver, By @by)
        {
            _uiElement = new SelectElement(driver.FindElement(by));
        }

        public void SelectByText(string text)
        {
            try
            {
               _uiElement.SelectByText(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new NotFoundException("No such element");
            }
        }

        public void SelectByValue(string value)
        {
            _uiElement.SelectByValue(value);
        }

        public void SelectById(int index)
        {
            _uiElement.SelectByIndex(index);
        }
        
    }
}