# Ten10 Interest Calculator Automation

This project is a Selenium C# automation framework for testing the Ten10 Interest Calculator application.  

---
## **Test Coverage**
Representative test cases automated in this project:

1. **Happy Path**
   - Input: Principal = 100, Rate = 5%, Duration = Yearly, Consent checked
   - Expected: 
     - Interest = 5.00
     - Total = 105.00

3. **Edge / Boundary Cases**
   - Principal = 0 → should show 0 interest or error.
   - Interest rate = 15% (upper bound).

4. **Negative / Invalid Input**
   - Invalid text input (if slider allows typing) → expect error or rejection.

5. **Rounding**
   - Example: Principal = 1000, Rate = 7%, Duration = Daily
   - Ensure interest and total are rounded to 2 decimal places.

---

## **Setup**

1. Clone the repo
2. Create a .env file with the following format:

TEN10_BASE_URL=http://3.8.242.61
TEN10_USER_EMAIL=demo@ten10.com
TEN10_USER_PASSWORD=Demo123!

3. Install dependencies
4. Run tests with dotnet test

Framework Notes

Uses Page Object Model (POM)

Environment variables are loaded via DotNetEnv.

Tests include login, interest calculation, and validation of error messages.

Only representative test cases were automated due to the 2-hour exploration window.