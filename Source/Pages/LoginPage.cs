using OpenQA.Selenium;
using Ten10Tests.Drivers;

namespace Ten10Tests.Source.Pages
{
    public class LoginPage : Driver
    {
        
        private By emailText = By.Id("UserName");
        private By passwordText = By.Id("Password");
        private By signInButton = By.Id("login-submit");

        public LoginPage()
        {
        }

         // Page URL
        private string BaseUrl => Environment.GetEnvironmentVariable("TEN10_BASE_URL") ?? "http://3.8.242.61";

        // Credentials
        private string Username => Environment.GetEnvironmentVariable("TEN10_USER_EMAIL") ?? "demo@ten10.com";
        private string Password => Environment.GetEnvironmentVariable("TEN10_USER_PASSWORD") ?? "Demo123!";

        public void Login()
        {
            _driver.Navigate().GoToUrl($"{BaseUrl}/Account/Login");
            
            _driver.FindElement(emailText, 2).SendKeys(Username);
            _driver.FindElement(passwordText, 5).SendKeys(Password);
            _driver.FindElement(signInButton, 5).Click();
        }
        
    }
}