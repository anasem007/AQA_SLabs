using System;
using OpenQA.Selenium;

namespace Saucedemo.BaseEntities
{
    public class BaseSteps
    {
        [ThreadStatic] protected static IWebDriver Driver;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}