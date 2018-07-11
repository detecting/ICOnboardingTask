using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Keys_Onboarding.Pages
{
    class FinancedetailsPage : BasePage
    {
        public FinancedetailsPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Define elements on Finance Detail Page

        //The page name
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Finance Details')]")]
        IWebElement TextFinancedetails { get; set; }

        //Define Purchase Price
        [FindsBy(
            How = How.XPath,
            Using = "//fieldset[@id='financeSection']//div[@class='ui grid']//div[1]//div[1]//input[1]")]
        IWebElement InputPurchasePrice { get; set; }

        //Define Mortgage
        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='ui grid']//div[2]//div[1]//input[1]")]
        IWebElement InputMortgage { get; set; }

        //Define HomeValue
        [FindsBy(
            How = How.XPath,
            Using = "//fieldset[@id=\'financeSection\']//div[@class=\'ui grid\']//div[3]//div[1]//input[1]")]
        IWebElement InputHomeValue { get; set; }

        //Define Home Value Type
        [FindsBy(
            How = How.XPath,
            Using = "//fieldset[@id=\'financeSection\']//div[@class=\'ui selection dropdown full width\']")]
        IWebElement DdlHomeValueType { get; set; }

        //Define Home Value Type List
        [FindsBy(
            How = How.XPath,
            Using = "//div[@class=\'menu transition visible\']")]
        IWebElement ListHomeValueType { get; set; }

        //Define Save button
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[8]/button[2]")]
        IWebElement BtnSave { get; set; }

        //Define Previous button
        [FindsBy(How = How.XPath, Using = "//div[@class='sixteen wide column text-center']//button[@class='ui button'][contains(text(),'Previous')]")]
        IWebElement BtnPrevious { get; set; }

        //Define Cancel button
        [FindsBy(How = How.XPath, Using = "//div[@class='sixteen wide column text-center']//input[@class='ui button']")]
        IWebElement BtnCancel { get; set; }

        //Define Next button
        [FindsBy(How = How.XPath,
            Using =
                "//div[@class='sixteen wide column text-center']//button[@class='ui teal button'][contains(text(),'Next')]")]
        public IWebElement BtnNext { get; set; }

        //Define Amount
        [FindsBy(How = How.XPath,
            Using = "//div[@class=\'four wide column\']//input[@type=\'text\']")]
        IWebElement InputAmount { get; set; }

        //Define StartDate
        [FindsBy(How = How.XPath,
            Using = "//input[@id=\'payment-start-date\']")]
        IWebElement InputStartDate { get; set; }

        //Define End Date
        [FindsBy(How = How.XPath,
            Using = "//input[@id='payment-end-date']")]
        IWebElement InputEndDate { get; set; }

        //Defube AddRepayment
        [FindsBy(How = How.XPath, Using = "//div[@class='eight wide column']//a[@href='javascript : void();']")]
        IWebElement BtnAddRepayment { get; set; }

        #endregion

        //Get the Name of Page
        string Financedetails()
        {
            return TextFinancedetails.Text;
        }

        //Set Purchas ePrice
        void PurchasePrice(string price)
        {
            InputPurchasePrice.Clear();
            InputPurchasePrice.SendKeys(price);
        }

        //Set Mortgage
        void Mortgage(string mortgage)
        {
            InputMortgage.Clear();
            InputMortgage.SendKeys(mortgage);
        }

        //Set Home Value
        void HomeValue(string value)
        {
            InputHomeValue.Click();
            InputHomeValue.SendKeys(value);
        }

        //Set Home Value Type
        void HomeValueType(string value)
        {
            DdlHomeValueType.Click();
            new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(3)).Until(
                ExpectedConditions.ElementExists(
                    By.XPath("//div[@class=\'menu transition visible\']")));
            var lists = ListHomeValueType.FindElements(By.TagName("div"));
            foreach (var item in lists)
            {
                if (item.Text == value)
                {
                    item.Click();
                }
            }
        }

        void Amount(string amount)
        {
            InputAmount.Clear();
            InputAmount.SendKeys(amount);
        }

        void StartDate()
        {
            InputStartDate.Clear();
            InputStartDate.SendKeys(DateTime.Now.ToString("d"));
        }

        void EndDate(string duration)
        {
            InputEndDate.Clear();
            InputEndDate.SendKeys(DateTime.Now.AddDays(int.Parse(duration)).ToString("d"));
        }

        void ClickAddRepayment()
        {
            BtnAddRepayment.Click();
        }

//        public MyPropertiesPage Save()
//        {
//            if (BtnSave.Displayed && BtnSave.Enabled)
//            {
//                BtnSave.Click();
//
//                // waiting for the new page to loaded.
//                new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10)).Until(
//                    ExpectedConditions.ElementExists(
//                        By.XPath("/html[1]/body[1]/div[2]/section[1]/div[1]/div[1]/div[3]/div[1]")));
//                return new MyPropertiesPage();
//            }
//
//            return null;
//        }

        public void FillAddRepayment()
        {
            //Click AddRepayment button
            ClickAddRepayment();
            //Wait for the element show up
            Driver.WaitForElementExist(By.XPath("//div[@data-bind=\'foreach: Repayments\']//div[@class=\'ui grid\']"), 2);
            //Get data from excel
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "FinanceDetails");
            //Set Amount
            Amount(CommonMethods.ExcelLib.ReadData(2, "Amount"));
            //Set Satrt date
            StartDate();
            //Set End Date
            EndDate(CommonMethods.ExcelLib.ReadData(2, "Duration"));
        }

        public void FillFinanceDetailsPage()
        {
            //Get data from excel
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "FinanceDetails");
            //Set Purchase Price
            PurchasePrice(CommonMethods.ExcelLib.ReadData(2, "PurchasePrice"));
            //Set Mortgage
            Mortgage(CommonMethods.ExcelLib.ReadData(2, "Mortgage"));
            //Set Home Value
            HomeValue(CommonMethods.ExcelLib.ReadData(2, "HomeValue"));
            //Select Home value type
            HomeValueType(CommonMethods.ExcelLib.ReadData(2, "HomeValueType"));
        }

        public void VerifyFinanceDetailsPage()
        {
            try
            {
                Driver.WaitForElementClickable(
                    By.XPath(
                        "//div[@class=\'sixteen wide column text-center\']//button[@class=\'ui teal button\'][contains(text(),\'Next\')]"),
                    2);
                if (BtnNext.Displayed && BtnNext.Enabled)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,
                        "Finance  Detail Page testing Passed, Fill the detail successfull");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                        "Finance  Detail Page testing Failed, Fill the detail Unsuccessfull");
                }
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                    "Finance Detail Page testing Failed, Fill the detail Unsuccessfull",
                    e.Message);
            }
        }

        public TenantDetailsPage ClickNext()
        {
            while (!BtnNext.Displayed && BtnNext.Enabled)
            {
                Thread.Sleep(100);
            }

            BtnNext.Click();
            return new TenantDetailsPage();
        }
    }
}