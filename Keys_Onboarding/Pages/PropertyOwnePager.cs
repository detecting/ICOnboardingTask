using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using Keys_Onboarding.Pages;
using static Keys_Onboarding.Global.CommonMethods;


namespace Keys_Onboarding
{
    public class PropertyOwnerPage : BasePage
    {
        public PropertyOwnerPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region WebElements Definition

        // Define  Add New Property button
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/a[2]")]
        IWebElement AddNewPropertyBtn { get; set; }

        //Define List A Rental button
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/a[1]")]
        IWebElement BtnListRental { get; set; }

        //Define Owners tab
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]")]
        IWebElement Ownertab { set; get; }

        // Find Owner List
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]")]
        IWebElement OwnerList { get; set; }

        //Define Properties page
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]")]
        IWebElement Properties { set; get; }

        //Define search bar        
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/input[1]")]
        IWebElement SearchBar { set; get; }

        //Define search button

        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/i[1]")]
        IWebElement SearchButton { set; get; }

        #endregion

        internal AddNewPropertyPage ClickAddNewPropertyBtn()
        {
            //Click AddNewPropertyBtn
            (Driver.WaitForElementClickable(
                By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/a[2]"), 5)).Click();
            //waiting for the URL change
            while (!Driver.driver.Url.Contains("AddNewProperty"))
            {
                Thread.Sleep(100);
            }

            return new AddNewPropertyPage();
        }

        internal ListRentalPage ClickListRental()
        {
            Driver.WaitForElementClickable(
                By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/a[1]"), 5);
            BtnListRental.Click();

            //waiting for the URL change
            while (!Driver.driver.Url.Contains("ListRental"))
            {
                Thread.Sleep(100);
            }

            return new ListRentalPage();
        }

        internal void SearchAProperty()
        {
            try
            {
                //Calling the common methods
                //Enter the value in the search bar
                SearchBar.SendKeys("Morgan");

                //Click on the search button
                SearchButton.Click();

                string ExpectedValue = "Morgan";
                string ActualValue = Driver.driver
                    .FindElement(
                        By.XPath(
                            "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]/h3[1]"))
                    .Text;

                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Search successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search  ");
            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull",
                    e.Message);
            }
        }
    }
}