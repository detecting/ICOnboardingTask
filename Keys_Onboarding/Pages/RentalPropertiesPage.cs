using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys_Onboarding.Global;
using MongoDB.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys_Onboarding.Pages
{
    public class RentalPropertiesPage : BasePage
    {
        public RentalPropertiesPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region define elements

        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]")]
        IWebElement DdlSortBy { get; set; }

        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]")]
        IWebElement ListSortBy { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[3]/div[1]")]
        IWebElement ListRentalListings { get; set; }

        #endregion

        #region page methods

        // sort lsit by time new to old
        public void SortBy(string sortBy)
        {
            //click the sort by 
            DdlSortBy.Click();
            //get the list of sort by
            var Lists = Driver.WaitForElementClickable(
                    By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]"), 2)
                .FindElements(By.TagName("div"));
            //select the item
            foreach (var item in Lists)
            {
                if (item.Text.Replace(System.Environment.NewLine, String.Empty).Trim() == sortBy)
                {
                    item.Click();
                    goto Done;
                }
            }

            Done:
            //wait for the page 
            while (!Driver.driver.Url.Contains("SortOrder"))
            {
                Thread.Sleep(100);
            }
        }

        public void CheckRentalWhichAdded()
        {
            try
            {
                // get the type of sort by
                CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "RentalProperties");
                SortBy(CommonMethods.ExcelLib.ReadData(2, "SortBy"));
                //get the inputed title
                CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "ListRentalProperty");
                string expectation = CommonMethods.ExcelLib.ReadData(2, "Title");
                //title lists
                var lists = ListRentalListings.FindElements(By.TagName("a"));
                //iterate to check expectation equals to dispalyed title
                foreach (var item in lists)
                {
                    if (item.Text == expectation)
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,
                            "Result Searching testing Passed, Search result by Rental Title name successfull");
                        //stop when gettiing the expected title
                        goto Done;
                    }
                }

                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                    "Result Searching testing Failed, Search result by Rental Title name Unsuccessfull");
                Done:
                return;
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message);
            }
        }
        #endregion
    }
}