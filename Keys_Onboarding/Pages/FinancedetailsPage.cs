using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/h2[1]")]
        IWebElement TextFinancedetails { get; set; }

        //Define Purchase Price
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[1]/div[1]/div[1]/input[1]")]
        IWebElement InputPurchasePrice { get; set; }

        //Define Mortgage
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[1]/div[2]/div[1]/input[1]")]
        IWebElement InputMortgage { get; set; }

        //Define HomeValue
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[1]/div[3]/div[1]/input[1]")]
        IWebElement InputHomeValue { get; set; }

        //Define Home Value Type
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[1]/div[4]/div[1]")]
        IWebElement DdlHomeValueType { get; set; }

        //Define Home Value Type List
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[1]/div[4]/div[1]/div[2]")]
        IWebElement ListHomeValueType { get; set; }

        //Define Save button
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[8]/button[2]")]
        IWebElement BtnSave { get; set; }

        //Define Previous button
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[8]/button[1]")]
        IWebElement BtnPrevious { get; set; }

        //Define Cancel button
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[8]/input[1]")]
        IWebElement BtnCancel { get; set; }

        //Define Next button
        [FindsBy(How = How.XPath,
            Using =
                "//div[@class='sixteen wide column text-center']//button[@class='ui teal button'][contains(text(),'Next')]")]
        public IWebElement BtnNext { get; set; }

        //Define Amount
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[3]/div[1]/div[1]/div[1]/input[1]")]
        public IWebElement InputAmount { get; set; }

        //Define StartDate
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[3]/div[1]/div[3]/div[1]/input[1]")]
        IWebElement InputStartDate { get; set; }

        //Define End Date
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[3]/div[1]/div[4]/div[1]/input[1]")]
        IWebElement InputEndDate { get; set; }

        //Defube AddRepayment
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[4]/div[1]/a[1]")]
        IWebElement BtnAddRepayment { get; set; }

        #endregion

        //Get the Name of Page
        public string Financedetails()
        {
            return TextFinancedetails.Text;
        }

        //Set Purchas ePrice
        public void PurchasePrice(string price)
        {
            InputPurchasePrice.Clear();
            InputPurchasePrice.SendKeys(price);
        }

        //Set Mortgage
        public void Mortgage(string mortgage)
        {
            InputMortgage.Clear();
            InputMortgage.SendKeys(mortgage);
        }

        //Set Home Value
        public void HomeValue(string value)
        {
            InputHomeValue.Click();
            InputHomeValue.SendKeys(value);
        }

        //Set Home Value Type
        public void HomeValueType(string value)
        {
            DdlHomeValueType.Click();
            new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(3)).Until(
                ExpectedConditions.ElementExists(
                    By.XPath("/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[2]/div[1]/div[4]/div[1]/div[2]")));
            var lists = ListHomeValueType.FindElements(By.TagName("div"));
            foreach (var item in lists)
            {
                if (item.Text == value)
                {
                    item.Click();
                }
            }
        }

        public void Amount(string amount)
        {
            InputAmount.Clear();
            InputAmount.SendKeys(amount);
        }

        public void StartDate()
        {
            InputStartDate.Clear();
            InputStartDate.SendKeys(DateTime.Now.ToString("d"));
        }

        public void EndDate(string duration)
        {
            InputEndDate.Clear();
            InputEndDate.SendKeys(DateTime.Now.AddDays(int.Parse(duration)).ToString("d"));
        }

        public void ClickAddRepayment()
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
            Driver.WaitForElementExist(By.XPath("/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[3]"), 2);
            //Get data from excel
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "FinanceDetails");
            //Set Amount
            Amount(CommonMethods.ExcelLib.ReadData(2, "Amount"));
            //Set Satrt date
            StartDate();
            //Set End Date
            EndDate(CommonMethods.ExcelLib.ReadData(2, "EndDate"));

        }

        public void FillFinanceDetailsPage()
        {
        }
    }
}