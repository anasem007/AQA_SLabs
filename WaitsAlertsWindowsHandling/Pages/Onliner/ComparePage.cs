using System;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandling.BaseEntities;

namespace WaitsAlertsWindowsHandling.Pages.Onliner
{
    public class ComparePage : BasePage
    {
        private static readonly By ButtonForPageOpenedBy = By.XPath("(//a[@class='button button_orange'])[1]");
        private static readonly By ScreenDiagonalBy = By.XPath("//span[contains(text(), 'Диагональ экрана')]");
        public readonly By ProductTableTipBy = By.Id("productTableTip");
        public readonly By ScreenDiagonalIconBy = By.XPath("//span[@data-tip-term='Диагональ экрана']");
        private static readonly By DeleteFirstProductButtonBy =
            By.XPath("(//div[@class='product-summary']//following-sibling::a[@title='Удалить'])[1]");

        public ComparePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        public ComparePage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ButtonForPageOpened.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement ButtonForPageOpened => _wait.GetVisibleElement(ButtonForPageOpenedBy);
        public IWebElement ScreenDiagonal => Driver.FindElement(ScreenDiagonalBy);
        public IWebElement ProductTableTip =>Driver.FindElement(ProductTableTipBy);
        public IWebElement ScreenDiagonalIcon => Driver.FindElement(ScreenDiagonalIconBy);
        public IWebElement DeleteFirstProduct => Driver.FindElement(DeleteFirstProductButtonBy);
    }
}