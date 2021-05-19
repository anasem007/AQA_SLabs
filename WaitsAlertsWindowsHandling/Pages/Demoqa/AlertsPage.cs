using System;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandling.BaseEntities;

namespace WaitsAlertsWindowsHandling.Pages.Demoqa
{
    public class AlertsPage : BasePage
    {
        private static string URL = "https://demoqa.com/alerts";

        private static readonly By SimpleAlertButtonBy = By.Id("alertButton");
        private static readonly By TimerAlertButtonBy = By.Id("timerAlertButton");
        private static readonly By ConfirmAlertButtonBy = By.Id("confirmButton");
        private static readonly By PromtAlertButtonBy = By.Id("promtButton");

        public AlertsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return SimpleAlertButton.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement SimpleAlertButton => _wait.GetVisibleElement(SimpleAlertButtonBy);
        public IWebElement TimerAlertButton => Driver.FindElement(TimerAlertButtonBy);
        public IWebElement ConfirmAlertButton => Driver.FindElement(ConfirmAlertButtonBy);
        public IWebElement PromtAlertButton => Driver.FindElement(PromtAlertButtonBy);
    }
}