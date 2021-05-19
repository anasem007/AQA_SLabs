using System;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandling.BaseEntities;

namespace WaitsAlertsWindowsHandling.Pages.Onliner
{
    public class TvPage : BasePage
    {
        private const string Url = "https://catalog.onliner.by/tv";

        private static readonly By FirstTvCheckboxBy =
            By.XPath(
                "(//div[@class='schema-product']/div/div/div/label)[1]");
        private static readonly By SecondTvCheckboxBy =
            By.XPath(
                "(//div[@class='schema-product']/div/div/div/label)[2]");
        private static readonly By CompareButtonBy = By.XPath("//a[@class='compare-button__sub compare-button__sub_main'][1]");

        private static readonly By AppleStoreButtonBy =
            By.XPath("//a[contains(@class, 'item_apple')]");

        private static readonly By GooglePlayButtonBy =
            By.XPath("//a[contains(@class, 'item_google')]");
        
        public TvPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public TvPage(IWebDriver driver) : base(driver, false)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return FirstTvCheckbox.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement FirstTvCheckbox => _wait.GetClickableElement(FirstTvCheckboxBy);
        public IWebElement SecondTvCheckbox => Driver.FindElement(SecondTvCheckboxBy);
        public IWebElement CompareButton => _wait.GetVisibleElement(CompareButtonBy);
        public IWebElement AppleStoreButton => Driver.FindElement(AppleStoreButtonBy);
        public IWebElement GooglePlayButton => Driver.FindElement(GooglePlayButtonBy);
    }
}