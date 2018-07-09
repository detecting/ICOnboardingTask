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

        //Define Owners tab
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]")]
        private IWebElement Ownertab { set; get; }

        // Find Owner List
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]")]
        IWebElement OwnerList { get; set; }

        //Define Properties page
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]")]
        private IWebElement Properties { set; get; }

        //Define search bar        
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/input[1]")]
        private IWebElement SearchBar { set; get; }

        //Define search button

        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/i[1]")]
        private IWebElement SearchButton { set; get; }

        #endregion

        public void Common_methods()
        {

            //Click on the Owners tab
            Ownertab.Click();
            // Wait for the Properties can be click
            while (!(OwnerList.Displayed && OwnerList.Enabled))
            {
                Thread.Sleep(100);
            }

            //Select properties page
            Properties.Click();
        }

        internal void SearchAProperty()
        {
            try
            {

                //Calling the common methods
//                Common_methods();

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
    }
}