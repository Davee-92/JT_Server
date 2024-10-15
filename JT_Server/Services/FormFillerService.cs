using JT_Server.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;

namespace JT_Server.Services
{
    public class FormFillerService
    {
        public void FillMicrosoftForm(string url, TaskData taskData)
        {
            var options = new ChromeOptions();
            options.AddArgument("--lang=en");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            //options.AddArgument("--headless"); // Odkomentuj, jeśli chcesz tryb headless

            using var driver = new ChromeDriver(options);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {
                driver.Navigate().GoToUrl(url);

                // First_name
                var First_name = wait.Until(drv => drv.FindElement(By.CssSelector("[aria-labelledby='QuestionId_r3c1f4d1c52d646338fe05748fb7ebf88 QuestionInfo_r3c1f4d1c52d646338fe05748fb7ebf88']")));
                First_name.SendKeys(taskData.First_Name);

                // Last_name
                var Last_name = wait.Until(drv => drv.FindElement(By.CssSelector("[aria-labelledby='QuestionId_r58d292c358804e45b9da5f99f4783b88 QuestionInfo_r58d292c358804e45b9da5f99f4783b88']")));
                Last_name.SendKeys(taskData.Last_Name);

                // Personal_Number
                var Personal_Number = wait.Until(drv => drv.FindElement(By.CssSelector("[aria-labelledby='QuestionId_rd3c35045353b43dfa790ee8794c6e242 QuestionInfo_rd3c35045353b43dfa790ee8794c6e242']")));
                Personal_Number.SendKeys(taskData.Personal_Number);

                // SAP_login
                var SAP_login = wait.Until(drv => drv.FindElement(By.CssSelector("[aria-labelledby='QuestionId_r83f2c858c8bb425bb1249f4ac5037f55 QuestionInfo_r83f2c858c8bb425bb1249f4ac5037f55']")));
                SAP_login.SendKeys(taskData.SAP_login);

                // Date
                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
                IWebElement DateInput = driver.FindElement(By.CssSelector("[aria-labelledby='QuestionId_r943d2c9e90694af5a9755047da1f5b40 QuestionInfo_r943d2c9e90694af5a9755047da1f5b40']"));
                DateInput.SendKeys(formattedDate);

                // Total_Hours
                var Total_Hours = wait.Until(drv => drv.FindElement(By.CssSelector("[aria-labelledby='QuestionId_r34567b4848da468cbf4be97fd7d2fa06 QuestionInfo_r34567b4848da468cbf4be97fd7d2fa06']")));
                Total_Hours.SendKeys(taskData.Total_Hours);

                
                // Gotowe do tego momentu.



                var submitButton = wait.Until(drv => drv.FindElement(By.CssSelector("button[type='submit']"))); // Czeka na kliknięcie
                submitButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while filling form: {ex.Message}");
            }
            finally
            {
                //driver.Quit();        // Zamknij przeglądarkę
            }
        }
    }
}
