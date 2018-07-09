using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using Keys_Onboarding.Pages;
using MongoDB.Driver;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Global
{
    internal class LoginPage : BasePage
    {
        //create constructor
        public LoginPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }


        #region  Initialize Web Elements 

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "//*[@id='UserName']")]
        private IWebElement Email { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement PassWord { get; set; }

        // Finding the LoginPage Button
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[4]/button[1]")]
        private IWebElement loginButton { get; set; }

        // Finding the Skip Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div/div[5]/a[1]")]
        IWebElement SkipBtn { get; set; }

        #endregion

        internal DashboardPage LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LoginPage");

            // Navigating to LoginPage page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(3, "Url"));

            // Sending the username 
            Email.SendKeys(ExcelLib.ReadData(3, "Email"));

            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(3, "Password"));

            // Clicking on the login button
            loginButton.Click();

            // Wait for Skip to show up and then click to goto dashboard page
            (Driver.WaitForElementClickable(By.XPath("/html/body/div[5]/div/div[5]/a[1]"), 5)).Click();
            return new DashboardPage();
        }
    }
}