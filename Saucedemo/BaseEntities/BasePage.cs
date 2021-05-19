using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Saucedemo.Services;

namespace Saucedemo.BaseEntities
{
    public abstract class BasePage
    {
        [ThreadStatic] protected static IWebDriver Driver;
        protected WaitService _wait;
        
        protected abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            _wait = new WaitService(driver);

            if (openPageByUrl)
            {
                OpenPage();
            }

            WaitForOpen();
        }

        protected void WaitForOpen()
        {
            if (!IsPageOpened())
            {
                throw new AssertionException("Page was not opened.");
            }
        }
    }
}