# Ten10 Interest Calculator Automation

This project is a Selenium C# automation framework for testing the Ten10 Interest Calculator application.  

---
## **Test Coverage**
Representative test cases automated in this project:

- **Happy Path**
   - Input: Principal = 100, Rate = 5%, Duration = Yearly, Consent checked
   - Expected: 
     - Interest = 5.00
     - Total = 105.00

- **Edge / Boundary Cases**
   - Principal = 0 → should show 0 interest or error.
   - Interest rate = 15% (upper bound).

- **Negative / Invalid Input**
   - Invalid text input (if slider allows typing) → expect error or rejection.

- **Rounding**
   - Example: Principal = 1000, Rate = 7%, Duration = Daily
   - Ensure interest and total are rounded to 2 decimal places.

---

## **Setup**

This project automates functional test cases for the Interest Calculator Web Application, focusing on clean design, maintainability, and real-world automation practices.
It is built in C# (.NET 8) using Selenium WebDriver, NUnit, and WebDriverManager for automatic browser compatibility.

Tech Stack:
   Language:	C# (.NET 8.0)
   Test Runner:	NUnit
   UI Automation:	Selenium WebDriver
   Driver Management:	WebDriverManager
   Config Management:	DotNetEnv
   IDE:	Visual Studio Code

Prerequisites:
Please ensure the following are installed:
   .NET SDK 8.0+
   Google Chrome
   (Optional) Visual Studio Code
   with the C# Dev Kit extension

The framework uses WebDriverManager to automatically match the correct ChromeDriver version — no manual driver setup required.

Getting Started
1. Clone the Repository
   git clone https://github.com/ManiSC18/Ten10Tests.git
   cd Ten10InterestCalcAutomation

2. Configure Environment Variables
   The framework loads environment variables using DotNetEnv.
   Create a .env file in the project root (same level as the .csproj file).

   Example:
   TEN10_BASE_URL=http://3.8.242.61
   TEN10_USER_EMAIL=demo@ten10.com
   TEN10_USER_PASSWORD=Demo123!

   Do not commit .env files to source control. Use .env.example for sharing safe templates.

3. Restore Dependencies
   Run the following command to install all required NuGet packages:
   dotnet restore

   The key dependencies are listed in Ten10Tests.csproj:

   <PackageReference Include="NUnit" Version="3.14.0" />
   <PackageReference Include="Selenium.WebDriver" Version="4.35.0" />
   <PackageReference Include="Selenium.Support" Version="4.35.0" />
   <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="140.0.7339.20700" />
   <PackageReference Include="WebDriverManager" Version="2.17.6" />
   <PackageReference Include="DotNetEnv" Version="3.1.1" />
   <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
   <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
   <PackageReference Include="coverlet.collector" Version="6.0.0" />

4. Run the Tests
   Run all tests via the CLI:
   dotnet test

   Or, inside VS Code:
   Open the project folder.

   Go to Testing Sidebar (flask icon).

   Click Run All Tests.

Common Issues & Fixes:

It was not possible to find any compatible framework version	Missing .NET 8 SDK	Install .NET 6 or later, or change <TargetFramework> to net6.0

SessionNotCreatedException: This version of ChromeDriver only supports Chrome version XX	ChromeDriver mismatch	WebDriverManager will auto-fix this; ensure Chrome is up to date

Test immediately fails on navigation	.env not found or variables empty	Copy .env.example → .env

No tests appear in Test Explorer	Wrong project type	Ensure <IsTestProject>true</IsTestProject> in .csproj

--

Design Principles
Page Object Model (POM) for reusability

Explicit waits to stabilize UI tests

Environment configuration for test flexibility

Self-healing driver setup using WebDriverManager

Only representative test cases were automated due to the 2-hour exploration window.