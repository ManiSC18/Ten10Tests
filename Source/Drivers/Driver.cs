using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Ten10Tests.Drivers
{

    public class Driver
    {
        [ThreadStatic]
        public static IWebDriver _driver;

        [SetUp]
        public void InitScript()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }
        
        [TearDown]
        public void Cleanup()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}