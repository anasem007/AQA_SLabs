using NLog;
using NUnit.Framework;
using WaitsAlertsWindowsHandling.BaseEntities;
using WaitsAlertsWindowsHandling.Pages.Demoqa;

namespace WaitsAlertsWindowsHandling.Tests
{
    public class AlertTest : BaseTest
    {
        private AlertsPage _alertsPage;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void SetUp()
        {
            _alertsPage = new AlertsPage(Driver, true);
        }
        
        [Test]
        public void PracticalTask_Alerts_SimpleAlert()
        {
            _alertsPage.SimpleAlertButton.Click();
            var simpleAlert = Driver.SwitchTo().Alert();
            Logger.Info(simpleAlert.Text);
            simpleAlert.Accept();
        }
        
        [Test]
        public void PracticalTask_Alerts_TimerAlert()
        {
            _alertsPage.TimerAlertButton.Click();
            var timerAlert = _wait.AlertIsPresent();
            Logger.Info(timerAlert.Text);
            timerAlert.Accept();
        }
        
        [Test]
        public void PracticalTask_Alerts_ConfirmAlert()
        {
            _alertsPage.ConfirmAlertButton.Click();
            var alert = Driver.SwitchTo().Alert();
            Logger.Info(alert.Text);
            alert.Accept();
            _alertsPage.ConfirmAlertButton.Click();
            alert.Dismiss();
        }
        
        [Test]
        public void PracticalTask_Alerts_PromtAlert()
        {
            _alertsPage.PromtAlertButton.Click();
            var alert = Driver.SwitchTo().Alert();
            Logger.Info(alert.Text);
            alert.SendKeys("Great site");
            alert.Accept();
        }
    }
}