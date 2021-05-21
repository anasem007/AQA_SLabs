using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using Saucedemo.Models;
using saucedemo.Services;
using Saucedemo.Services;

namespace Saucedemo.BaseEntities
{
    public class BaseTest
    {
        public static readonly string BaseUrl = Configurator.BaseUrl;
        public User User;
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new BrowserService().WebDriver;
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            User = UserService.GetUser("standard_user");
        }

    }
}