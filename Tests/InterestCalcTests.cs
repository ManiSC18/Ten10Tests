using Ten10Tests.Drivers;
using Ten10Tests.Pages;
using Ten10Tests.Source.Pages;


namespace Ten10Tests.Tests
{
    public class InterestCalcTests : Driver
    {
        //Happy path test case
        [Test]
        public void Should_CalculateYearlyInterestCorrectly()
        {
            var loginPage = new LoginPage();
            loginPage.Login();
            var page = new InterestCalcPage();
            page.EnterPrincipalAmount(1000);
            page.EnterInterestRate("5%");
            page.SelectDuration("Yearly");
            page.GiveConsent();
            page.ClickCalculate();

            Assert.That(page.GetInterestResult(), Is.EqualTo("Interest Amount: 50.00"));
            Assert.That(page.GetTotalResult(), Is.EqualTo("Total Amount with Interest: 1050.00"));
        }

        //Edge case (Upper Bound Interest) test case
        [Test]
        public void Should_CalculateYearlyInterestCorrectly_MaxInterestRate()
        {
            var loginPage = new LoginPage();
            loginPage.Login();
            var page = new InterestCalcPage();
            page.EnterPrincipalAmount(1000);
            page.EnterInterestRate("15%");
            page.SelectDuration("Yearly");
            page.GiveConsent();
            page.ClickCalculate();

            Assert.That(page.GetInterestResult(), Is.EqualTo("Interest Amount: 150.00"));
            Assert.That(page.GetTotalResult(), Is.EqualTo("Total Amount with Interest: 1150.00"));
        }

        //Edge case (Lower Bound Principal) test case
        [Test]
        public void Should_HandlePrincipalInterestAt0()
        {
            var loginPage = new LoginPage();
            loginPage.Login();
            var page = new InterestCalcPage();
            page.EnterPrincipalAmount(0);
            page.EnterInterestRate("15%");
            page.SelectDuration("Yearly");
            page.GiveConsent();
            page.ClickCalculate();

            string alertMessage = page.GetAndAcceptAlert();
            Assert.That(alertMessage, Is.EqualTo("Please enter a principal amount greater than zero."));
        }

        //Negative case test case
        [Test]
        public void Should_ShowAlert_WhenMissingFields()
        {
            var loginPage = new LoginPage();
            loginPage.Login();
            var page = new InterestCalcPage();

            // Only set principal, leave other fields empty
            page.EnterPrincipalAmount(1000);
            page.ClickCalculate();

            string alertMessage = page.GetAndAcceptAlert();

            Assert.That(alertMessage, Is.EqualTo("Please fill in all fields."));
        }

        //Happy path test case for rounding
        [Test]
        public void Should_CalculateDailyInterestCorrectly_ToTwoDecimalPlaces()
        {
            var loginPage = new LoginPage();
            loginPage.Login();
            var page = new InterestCalcPage();
            page.EnterPrincipalAmount(1000);
            page.EnterInterestRate("7%");
            page.SelectDuration("Daily");
            page.GiveConsent();
            page.ClickCalculate();

            Assert.That(page.GetInterestResult(), Is.EqualTo("Interest Amount: 0.19"));
            Assert.That(page.GetTotalResult(), Is.EqualTo("Total Amount with Interest: 1000.19"));
        }
    }
}