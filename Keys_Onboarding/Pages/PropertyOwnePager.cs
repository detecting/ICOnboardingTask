using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using Keys_Onboarding.Pages;
using MongoDB.Driver;
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

        //define properties lists
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]")]
        IWebElement PropertiesList { get; set; }

        #endregion

        #region page methods

        

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
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull");
            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull",
                    e.Message);
            }
        }

        // fill the search box and click search button
        void FillSearchBoxAndCLickSearch(string propertyName)
        {
            SearchBar.Clear();
            SearchBar.SendKeys(propertyName);
            SearchButton.Click();
        }

        void CheckResults(string propertyName, string propertyAdd)
        {
            var lists = PropertiesList.FindElements(By.TagName("div"));
            try
            {
                foreach (var item in lists)
                {
                    if (item.FindElement(By.TagName("h3")).Text == propertyName)

                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,
                            "Result Searching testing Passed, Search result by property name successfull");
                        goto Done;
                    }
              
                }

                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                    "Result Searching testing Failed, Search result by property name Unsuccessfull");
                Done:
                return;
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                    e.Message);
            }
        }

        public void SearchPropertiesWhichAdded()
        {
            //get input data from Excel 
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
            // get the Property Name which just input
            string propertyNameexpected = CommonMethods.ExcelLib.ReadData(2, "PropertyName");
            string propertyAdd = CommonMethods.ExcelLib.ReadData(2, "SearchAddress");
            //fill the search box and click the search button
            FillSearchBoxAndCLickSearch(propertyNameexpected);
            //wait for the page jumps
            while (!Driver.driver.Url.Contains("SearchString"))
            {
                Thread.Sleep(100);
            }

            //search the result and verify it.
            CheckResults(propertyNameexpected, propertyAdd);
        }
        #endregion

    }
}