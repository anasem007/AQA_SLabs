using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WaitsAlertsWindowsHandling.Services;

namespace WaitsAlertsWindowsHandling.BaseEntities
{
    public class BaseTest
    {
        public static readonly string BaseUrl = Configurator.BaseUrl;
        public IWebDriver Driver;        
        public Actions Actions;
        public WaitService _wait;

        [SetUp]
        public void Setup()
        {
            Driver = new BrowserService().WebDriver;
            Actions = new Actions(Driver);
            _wait = new WaitService(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

    }
}