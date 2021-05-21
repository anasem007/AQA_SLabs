using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Saucedemo.Core.Wrappers
{
    public class ItemsList
    {
        private readonly UiElement _uiElement;
        private readonly List<ListItem> _listItems = new List<ListItem>();

        public ItemsList(IWebDriver driver, By by, string itemClassName)
        {
            _uiElement = new UiElement(driver, by);

            foreach (var webElement in _uiElement.FindElements(By.ClassName($"{itemClassName}")))
            {
                _listItems.Add(new ListItem(driver, webElement));
            }
        }

        public ItemsList(IWebDriver driver, IWebElement webElement, string className)
        {
            _uiElement = new UiElement(driver, webElement);

            foreach (var element in driver.FindElements(By.ClassName($"{className}")))
            {
                _listItems.Add(new ListItem(driver, element));
            }
        }

        public int ItemsCount => _listItems.Count;

         public ListItem SelectItemByName(string name)
        {
            foreach (var item in _listItems.Where(item => item.Name.Text().Equals(name)))
            {
                return item;
            }

            throw new NotFoundException($"Item with such name {name} not found.");
        }

        public List<ListItem> GetAllItems()
        {
            return _listItems;
        }

        public List<string> ItemsPrices => _listItems.Select(listItem => listItem.Price).ToList();
        public List<string> ItemsNames => _listItems.Select(listItem => listItem.Name.Text()).ToList();
    }
}