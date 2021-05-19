using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandling.BaseEntities;
using WaitsAlertsWindowsHandling.Pages.Onliner;

namespace WaitsAlertsWindowsHandling.Tests
{
    public class WaitTest : BaseTest
    {
        private TvPage _tvPage;
        private ComparePage _comparePage;
        private IJavaScriptExecutor _javaScriptExecutor;
        
        [SetUp]
        public new void Setup()
        {
            _tvPage = new TvPage(Driver, true);
            _javaScriptExecutor = (IJavaScriptExecutor) Driver;
        }

        [Test]
        public void PracticalTask_Wait()
        {
            _tvPage.FirstTvCheckbox.Click();
            _tvPage.SecondTvCheckbox.Click();
            _tvPage.CompareButton.Click();
            _comparePage = new ComparePage(Driver);
            _javaScriptExecutor.ExecuteScript("window.scrollBy(0,250)", "");
            Actions
                .MoveToElement(_comparePage.ScreenDiagonal)
                .Perform();
            _wait.GetVisibleElement(_comparePage.ScreenDiagonalIconBy);
            _comparePage.ScreenDiagonalIcon.Displayed.Should().BeTrue();
            _comparePage.ScreenDiagonalIcon.Click();
            _wait.GetVisibleElement(_comparePage.ProductTableTipBy);
            _comparePage.ProductTableTip.Displayed.Should().BeTrue();
            _comparePage.ScreenDiagonalIcon.Click();
            _wait.ElementIsInvisible(_comparePage.ProductTableTipBy);
            _comparePage.ProductTableTip.Displayed.Should().BeFalse();
            _comparePage.DeleteFirstProduct.Click();
            _comparePage.ButtonForPageOpened.Displayed.Should().BeTrue();
        }
    }
}