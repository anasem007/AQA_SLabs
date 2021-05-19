using FluentAssertions;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandling.BaseEntities;
using WaitsAlertsWindowsHandling.Pages.Onliner;

namespace WaitsAlertsWindowsHandling.Tests
{
    public class MultiWindowTest : BaseTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void PracticalTask_MultiWindowHandling()
        {
            var tvPage = new TvPage(Driver, true);
            var parentWindowHandle = Driver.CurrentWindowHandle;
            tvPage.AppleStoreButton.Click();
            var appleStoreWindowHandle = Driver.WindowHandles[1];
            Driver.SwitchTo().Window(parentWindowHandle);
            tvPage.GooglePlayButton.Click();
            var googleStoreWindowHandle = Driver.WindowHandles[2];
            Driver.WindowHandles.Count.Should().Be(3);
            Driver.SwitchTo().Window(googleStoreWindowHandle);
            Driver.Title.Should().Be("Каталог Onliner - Apps on Google Play");
            Driver.FindElement(By.CssSelector("a.xjAeve")).Click();
            _wait.GetVisibleElement(By.CssSelector("div.ImZGtf"));
            Logger.Info(Driver.FindElements(By.CssSelector("div.ImZGtf")).Count);
            Driver.SwitchTo().Window(appleStoreWindowHandle);
            Driver.FindElement(By.CssSelector("button.we-truncate__button")).Click();
            Driver.Close();
            Driver.SwitchTo().Window(parentWindowHandle);
            Driver.FindElement(By.CssSelector("div.schema-product__ticket-trigger")).Click();
        }
    }
}