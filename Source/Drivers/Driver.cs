using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using DotNetEnv;

namespace Ten10Tests.Drivers
{

    public class Driver
    {
        [ThreadStatic]
        public static IWebDriver _driver;

        [OneTimeSetUp]
        public void LoadEnv()
        {
            // Get the project root relative to output directory
            string projectRoot = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);
            Env.Load(Path.Combine(projectRoot, ".env"));
        }

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