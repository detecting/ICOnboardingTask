using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys_Onboarding.Pages
{
    public class AddTenantDashboardPage : BasePage
    {
        public AddTenantDashboardPage()
        {
            PageFactory.InitElements(Driver.driver,this);
        }
        #region define elements

        //Define Tenant Email
        [FindsBy(How = How.XPath, Using = "//fieldset[@id=\'BasicDetail\']//input[@name=\'Email\']")]
        IWebElement InputTenantEmail { get; set; }

        //Define Is Mian Tenant
        [FindsBy(How = How.XPath,
            Using =
                "//fieldset[@id=\'BasicDetail\']//select[@data-bind=\'value : IsMainTenant\']")]
        IWebElement DdlIsMainTenant { get; set; }

        //Define First Name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First Name']")]
        IWebElement InputFirstName { get; set; }

        //Define Last Name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\'Last Name\']")]
        IWebElement InputLastName { get; set; }

        //Define Start date
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[1]/div[1]/input[1]")]
        IWebElement InputRentStartDate { get; set; }

        //define end date
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[2]/div[1]/input[1]")]
        IWebElement InputRentEndDate { get; set; }

        // define rent amount
        [FindsBy(How = How.XPath, Using = "//fieldset[@id=\'BasicDetail\']//input[@name=\'RentAmount\']")]
        IWebElement InputRentAmount { get; set; }

        // define Payment frequency
        [FindsBy(How = How.XPath,
            Using =
                "//fieldset[@id='BasicDetail']//select[@name='paymentfrequency']")]
        IWebElement DdlPaymentFrequancy { get; set; }

        // define Payment Start Date
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[7]/div[1]/div[1]/input[1]")]
        IWebElement InputPaymentStartDate { get; set; }

        //define Payment Due Day DDL
        [FindsBy(How = How.XPath,
            Using =
                "//*[@id=\"BasicDetail\"]/div[7]/div[2]/div[1]/select")]

        IWebElement DdlPaymentDueDay { get; set; }

        //define Next
        [FindsBy(How = How.XPath, Using = "//input[contains(@class,\'ui teal button\')]")]
        IWebElement BtnNext { get; set; }

        //define cancel
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,\'center aligned column\')]//input[2]")]
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
            var lists = DdlIsMainTenant.FindElements(By.TagName("option"));
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

        //set RentStartDate
        void RentStartDate()
        {
            InputRentStartDate.Clear();
            InputRentStartDate.SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        //set RentEndDate
        void RentEndDate(string duration)
        {
            InputRentEndDate.Clear();
            InputRentEndDate.SendKeys(DateTime.Now.AddDays(int.Parse(duration)).ToString("dd/MM/yyyy"));
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
            var lists = DdlPaymentFrequancy.FindElements(By.TagName("option"));
            foreach (var item in lists)
            {
                if (item.Text == paymentfrequency)
                {
                    item.Click();
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
            var lists = DdlPaymentDueDay.FindElements(By.TagName("option"));
            foreach (var item in lists)
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
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "AddTenantDetails");
            TenantEmail(DateTime.Now.ToString("hhmmss")+CommonMethods.ExcelLib.ReadData(2, "TenantEmail"));
            IsMainTenant(CommonMethods.ExcelLib.ReadData(2, "IsMainTenant"));
            FirstName(CommonMethods.ExcelLib.ReadData(2, "FirstName"));
            LastName(CommonMethods.ExcelLib.ReadData(2, "LastName"));
            RentStartDate();
            RentEndDate(CommonMethods.ExcelLib.ReadData(2, "Duraion"));
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
                Driver.WaitForElementClickable(By.XPath("//input[contains(@class,'ui teal button')]"), 2);
                if (BtnNext.Displayed && BtnNext.Enabled)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,
                        "Add Tenant Detail Page testing Passed, Fill the detail successfull");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                        "Add Tenant Detail Page testing Failed, Fill the detail Unsuccessfull");
                }
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                    e.Message);
            }
        }

        public LiabilitiesDetailsPage ClickNext()
        {
            while (!BtnNext.Displayed&&BtnNext.Enabled)
            {
                Thread.Sleep(100);
            }
            BtnNext.Click();
            return new LiabilitiesDetailsPage();
        }
        #endregion

    }
}