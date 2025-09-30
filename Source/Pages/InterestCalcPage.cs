using OpenQA.Selenium;
using Ten10Tests.Drivers;

namespace Ten10Tests.Pages
{
    public class InterestCalcPage : Driver
    {
        private By PrincipalInput = By.Id("customRange1");
        private By RateDropdown = By.Id("dropdownMenuButton");
        private By RateInput(string rate) => By.Id($"rate-{rate}");
        private By DurationOption(string duration) => By.CssSelector($"#durationList [data-value='{duration}']");
        private By ConsentCheckbox = By.Id("gridCheck1");
        private By CalculateButton => By.XPath("//button[text()='Calculate']");
        private By InterestAmountText => By.Id("interestAmount");
        private By TotalAmountText => By.Id("totalAmount");

        public InterestCalcPage()
        {
        }

        public void EnterPrincipalAmount(int principalAmount)
        {
            var slider = _driver.FindElement(PrincipalInput, 5);
            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].value = arguments[1]; arguments[0].dispatchEvent(new Event('input'));", slider, principalAmount);
        }

        public void EnterInterestRate(string rate)
        {
            _driver.FindElement(RateDropdown).Click();
            var rateElement = _driver.FindElement(RateInput(rate), 5);
            if (!rateElement.Selected)
                rateElement.Click();
            IWebElement body = _driver.FindElement(By.TagName("body"));
            body.Click();
        }

        public void SelectDuration(string duration)
        {
            var durationElement = _driver.FindElement(DurationOption(duration), 5);
            durationElement.Click();
        }

        public void GiveConsent()
        {
            var checkbox = _driver.FindElement(ConsentCheckbox, 5);
            if (!checkbox.Selected)
                checkbox.Click();
        }

        public void ClickCalculate()
        {
            _driver.FindElement(CalculateButton, 5).Click();
        }

        public string GetInterestResult() => _driver.FindElement(InterestAmountText, 5).Text;
        public string GetTotalResult() => _driver.FindElement(TotalAmountText, 5).Text;

        public string GetAndAcceptAlert()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            string message = alert.Text;
            alert.Accept();
            return message;
        }
    }

}