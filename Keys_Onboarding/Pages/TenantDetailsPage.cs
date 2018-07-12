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
    class TenantDetailsPage : BasePage
    {
        public TenantDetailsPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region define elements

        //Define Tenant Email
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        IWebElement InputTenantEmail { get; set; }

        //Define Is Mian Tenant
        [FindsBy(How = How.XPath,
            Using =
                "//*[@id=\"tenantSection\"]/div[1]/div[2]/div")]
        IWebElement DdlIsMainTenant { get; set; }

        //List of Mian Tenant
        [FindsBy(How = How.XPath, Using = "//div[@class='menu transition visible']")]
        IWebElement ListMianTenant { get; set; }

        //Define First Name
        [FindsBy(How = How.XPath, Using = "//input[@id='fname']")]
        IWebElement InputFirstName { get; set; }

        //Define Last Name
        [FindsBy(How = How.XPath, Using = "//input[@id='lname']")]
        IWebElement InputLastName { get; set; }

        //Define Start date
        [FindsBy(How = How.XPath, Using = "//input[@id='sdate']")]
        IWebElement InputStartDate { get; set; }

        //define end date
        [FindsBy(How = How.XPath, Using = "//input[@id='edate']")]
        IWebElement InputEndDate { get; set; }

        // define rent amount
        [FindsBy(How = How.XPath, Using = "//input[@id='ramount']")]
        IWebElement InputRentAmount { get; set; }

        // define Payment frequency
        [FindsBy(How = How.XPath,
            Using =
                "//*[@id=\"tenantSection\"]/div[1]/div[8]/div")]
        IWebElement DdlPaymentFrequancy { get; set; }

        // define List of payment frequency
        [FindsBy(How = How.XPath, Using = "//div[@class='menu transition visible']")]
        IWebElement ListPaymentFrequancy { get; set; }

        // define Payment Start Date
        [FindsBy(How = How.XPath, Using = "//input[@id='psdate']")]
        IWebElement InputPaymentStartDate { get; set; }

        //define Payment Due Day DDL
        [FindsBy(How = How.XPath,
            Using =
                "//*[@id=\"tenantSection\"]/div[1]/div[10]/div")]
        IWebElement DdlPaymentDueDay { get; set; }

        //define List Payment Due Day
        [FindsBy(How = How.XPath, Using = "//div[@class='menu transition visible']")]
        IWebElement ListPaymentDueDay { get; set; }

        //define add new liability
        [FindsBy(How = How.XPath, Using = "//a[@data-bind='click : AddLiabilityValues']")]
        IWebElement BtnAddNewLiability { get; set; }

        // define Previous
        [FindsBy(How = How.XPath, Using = "//button[@id=\'addProperty\']")]
        IWebElement BtnPrevious { get; set; }

        //define Save
        [FindsBy(How = How.XPath, Using = "//button[@id='saveProperty']")]
        IWebElement BtnSave { get; set; }

        //define cancel
        [FindsBy(How = How.XPath, Using = "//div[@class=\'sixteen wide text-center\']//input[@class=\'ui button\']")]
        IWebElement BtnCancel { get; set; }

        #endregion

        #region page methods

        //set TenantEmail
        void TenantEmail(string tenantEmail)
        {
            InputTenantEmail.Clear();
            InputTenantEmail.SendKeys(tenantEmail);
        }

        //set IsMainTenant
        void IsMainTenant(string isMainTenant)
        {
            DdlIsMainTenant.Click();
            Driver.WaitForElementExist(By.XPath("//div[@class='menu transition visible']"), 3);
            var lists = ListMianTenant.FindElements(By.TagName("div"));
            foreach (var item in lists)
            {
                if (item.Text == isMainTenant)
                {
                    item.Click();
                }
            }
        }

        //set FirstName
        void FirstName(string firstName)
        {
            InputFirstName.Clear();
            InputFirstName.SendKeys(firstName);
        }

        //set LastName
        void LastName(string lastName)
        {
            InputLastName.Clear();
            InputLastName.SendKeys(lastName);
        }

        //set StartDate
        void StartDate()
        {
            InputStartDate.Clear();
            InputStartDate.SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        //set EndDate
        void EndDate(string duration)
        {
            InputEndDate.Clear();
            InputEndDate.SendKeys(DateTime.Now.AddDays(int.Parse(duration)).ToString("dd/MM/yyyy"));
        }

        //set RentAmount
        void RentAmount(string rentAmount)
        {
            InputRentAmount.Clear();
            InputRentAmount.SendKeys(rentAmount);
        }

        //set Paymentfrequency
        void Paymentfrequency(string paymentfrequency)
        {
            DdlPaymentFrequancy.Click();
            var lists = Driver.WaitForElementExist(By.XPath("//div[@class='menu transition visible']"), 3)
                .FindElements(By.TagName("div"));
            foreach (var VARIABLE in lists)
            {
                if (VARIABLE.Text == paymentfrequency)
                {
                    VARIABLE.Click();
                }
            }
        }

        //set PaymentStartDate
        void PaymentStartDate()
        {
            InputPaymentStartDate.Clear();
            InputPaymentStartDate.SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        //set PaymentDueDay
        void PaymentDueDay(string paymentDueDay)
        {
            DdlPaymentDueDay.Click();
            var Lists = Driver.WaitForElementExist(By.XPath("//div[@class='menu transition visible']"), 3)
                .FindElements(By.TagName("div"));
            foreach (var item in Lists)
            {
                if (item.Text == paymentDueDay)
                {
                    item.Click();
                }
            }
        }

        //FillTheDetails
        public void FillTheDetails()
        {
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");
            TenantEmail(CommonMethods.ExcelLib.ReadData(2, "TenantEmail"));
            IsMainTenant(CommonMethods.ExcelLib.ReadData(2, "IsMainTenant"));
            FirstName(CommonMethods.ExcelLib.ReadData(2, "FirstName"));
            LastName(CommonMethods.ExcelLib.ReadData(2, "LastName"));
            StartDate();
            EndDate(CommonMethods.ExcelLib.ReadData(2, "Duraion"));
            RentAmount(CommonMethods.ExcelLib.ReadData(2, "RentAmount"));
            Paymentfrequency(CommonMethods.ExcelLib.ReadData(2, "Paymentfrequency"));
            PaymentStartDate();
            PaymentDueDay(CommonMethods.ExcelLib.ReadData(2, "PaymentDueDay"));
        }

        //verify the page 
        public void VerifyTenantDetailsPage()
        {
            try
            {
                Driver.WaitForElementClickable(By.XPath("//button[@id=\'saveProperty\']"), 2);
                if (BtnSave.Displayed && BtnSave.Enabled)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,
                        "Tenant Detail Page testing Passed, Fill the detail successfull");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                        "Tenant Detail Page testing Failed, Fill the detail Unsuccessfull");
                }
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                    e.Message);
            }
        }

        //click save button
        public PropertyOwnerPage ClickSave()
        {
            while (!BtnSave.Displayed && BtnSave.Enabled)
            {
                Thread.Sleep(100);
            }

            BtnSave.Click();
            while (!Driver.driver.Url.Contains("Home/Index"))
            {
                Thread.Sleep(100);
            }

            return new PropertyOwnerPage();
        }

        #endregion
    }
}