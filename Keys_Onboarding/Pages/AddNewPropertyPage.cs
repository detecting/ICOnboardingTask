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
    public class AddNewPropertyPage : BasePage
    {
        public AddNewPropertyPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Define Elements

        // Define PropertyName input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[2]/div[1]/div[1]/input[1]")]
        IWebElement InputPropertyName { get; set; }

        // Define PropertyType DDL
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[2]/div[2]/div[1]")]
        IWebElement DpdPropertyType { get; set; }

        // Define SearchAddress Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[1]/div[1]/input[1]")]
        IWebElement InputSearchAddress { get; set; }

        // Define Description Text
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[2]/div[1]/textarea[1]")]
        IWebElement TextDescription { get; set; }

        // Define TargetRent Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[4]/div[1]/div[1]/div[1]/input[1]")]
        IWebElement InputTargetRent { get; set; }

        // Define RentType DDL
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[4]/div[1]/div[2]/div[1]")]
        IWebElement DdpRentType { get; set; }

        // Define LandArea Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[1]/div[1]/input[1]")]
        IWebElement InputLandArea { get; set; }

        // Define FloorArea Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[2]/div[1]/input[1]")]
        IWebElement InputFloorArea { get; set; }

        // Define Bedrooms Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[6]/div[1]/div[1]/input[1]")]
        IWebElement InputBedrooms { get; set; }

        // Define Bathrooms Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[6]/div[2]/div[1]/input[1]")]
        IWebElement InputBathrooms { get; set; }

        // Define CarPark Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[7]/div[1]/div[1]/input[1]")]
        IWebElement InputCarparks { get; set; }

        // Define YearBuit Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[7]/div[2]/div[1]/input[1]")]
        IWebElement InputYearBuilt { get; set; }

        // Define OwnerOccupied Check Box
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[8]/div[1]/input[1]")]
        IWebElement CBOwnerOccupied { get; set; }

        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[9]/div[2]/div[1]/input[1]")]
        IWebElement FileUploadBtn { get; set; }

        //Define Next button
        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='center aligned column']//button[@class='ui teal button'][contains(text(),'Next')]")]
        IWebElement BtnNext { get; set; }

        #endregion

        //Fill propertyName
        void PropertyName(string propertyName)
        {
            InputPropertyName.Clear();
            InputPropertyName.SendKeys(propertyName);
        }

        // Fill propertyType
        void PropertyType(string propertyType)
        {
            // click the PropertyType
            DpdPropertyType.Click();

            // wait fot the lsit to show up
            IWebElement listPropertyType = Driver.WaitForElementExist(
                By.XPath("/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[2]/div[2]/div[1]/div[2]"), 5);
            var lists = listPropertyType.FindElements(By.TagName("div"));
            foreach (var item in lists)
            {
                if (item.Text == propertyType)
                {
                    item.Click();
                }
            }
        }

        //Fill searchAddress
        void SearchAddress(string searchAddress)
        {
            // clean the InputSearchAddress input
            InputSearchAddress.Clear();

            // full the InputSearchAddress
            InputSearchAddress.SendKeys(searchAddress);
            Thread.Sleep(1000);

            // press down key
            InputSearchAddress.SendKeys(Keys.ArrowDown);

            // press the enter key
            InputSearchAddress.SendKeys(Keys.Enter);
        }

        // Fill description
        void Description(string description)
        {
            TextDescription.Clear();
            TextDescription.SendKeys(description);
        }

        // Fill targetRent
        void TargetRent(string targetRent)
        {
            InputTargetRent.Clear();
            InputTargetRent.SendKeys(targetRent);
        }

        // Fill rentType
        void RentType(string rentType)
        {
            DdpRentType.Click();
            IWebElement listsDdpRentType = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(5)).Until(
                ExpectedConditions.ElementExists(
                    By.XPath(
                        "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[4]/div[1]/div[2]/div[1]/div[2]")));
            var lists = listsDdpRentType.FindElements(By.TagName("div"));
            foreach (var item in lists)
            {
                if (item.Text == rentType)
                {
                    item.Click();
                }
            }
        }

        // Fill landArea
        void LandArea(string landArea)
        {
            InputLandArea.Clear();
            InputLandArea.SendKeys(landArea);
        }

        // Fill floorArea
        void FloorArea(string floorArea)
        {
            InputFloorArea.Clear();
            InputFloorArea.SendKeys(floorArea);
        }

        // Fill bedrooms
        void Bedrooms(string bedrooms)
        {
            InputBedrooms.Clear();
            InputBedrooms.SendKeys(bedrooms);
        }

        // Fill bathrooms
        void Bathrooms(string bathrooms)
        {
            InputBathrooms.Clear();
            InputBathrooms.SendKeys(bathrooms);
        }

        // Fill carparks
        void Carparks(string carparks)
        {
            InputCarparks.Clear();
            InputCarparks.SendKeys(carparks);
        }

        // Fill yearBuilt
        void YearBuilt(string yearBuilt)
        {
            InputYearBuilt.Clear();
            InputYearBuilt.SendKeys(yearBuilt);
            InputYearBuilt.SendKeys(Keys.ArrowDown);
        }

        // Tick  OwnerOccupied
        void OwnerOccupied()
        {
            Thread.Sleep(1000);
            CBOwnerOccupied.Click();
            Thread.Sleep(1000);
        }

        //File Upload
        void FileUpload(string filePath)
        {
            FileUploadBtn.SendKeys(filePath);
        }

        public void FillAllFieldsWithoutTickOwnerOccupied()
        {
            // Populating the data from Excel
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");

            PropertyName(CommonMethods.ExcelLib.ReadData(2, "PropertyName"));
            PropertyType(CommonMethods.ExcelLib.ReadData(2, "PropertyType"));
            SearchAddress(CommonMethods.ExcelLib.ReadData(2, "SearchAddress"));
            Description(CommonMethods.ExcelLib.ReadData(2, "Description"));
            TargetRent(CommonMethods.ExcelLib.ReadData(2, "TargetRent"));
            RentType(CommonMethods.ExcelLib.ReadData(2, "RentType"));
            LandArea(CommonMethods.ExcelLib.ReadData(2, "LandArea"));
            FloorArea(CommonMethods.ExcelLib.ReadData(2, "FloorArea"));
            Bedrooms(CommonMethods.ExcelLib.ReadData(2, "Bedrooms"));
            Bathrooms(CommonMethods.ExcelLib.ReadData(2, "Bathrooms"));
            Carparks(CommonMethods.ExcelLib.ReadData(2, "Carparks"));
            YearBuilt(CommonMethods.ExcelLib.ReadData(2, "YearBuilt"));
            FileUpload(CommonMethods.ExcelLib.ReadData(2, "FilePath"));
        }

        //Fill all the detail of the page
        public void FillAllFields()
        {
            // Populating the data from Excel
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");

            PropertyName(CommonMethods.ExcelLib.ReadData(2, "PropertyName"));
            PropertyType(CommonMethods.ExcelLib.ReadData(2, "PropertyType"));
            SearchAddress(CommonMethods.ExcelLib.ReadData(2, "SearchAddress"));
            Description(CommonMethods.ExcelLib.ReadData(2, "Description"));
            TargetRent(CommonMethods.ExcelLib.ReadData(2, "TargetRent"));
            RentType(CommonMethods.ExcelLib.ReadData(2, "RentType"));
            LandArea(CommonMethods.ExcelLib.ReadData(2, "LandArea"));
            FloorArea(CommonMethods.ExcelLib.ReadData(2, "FloorArea"));
            Bedrooms(CommonMethods.ExcelLib.ReadData(2, "Bedrooms"));
            Bathrooms(CommonMethods.ExcelLib.ReadData(2, "Bathrooms"));
            Carparks(CommonMethods.ExcelLib.ReadData(2, "Carparks"));
            YearBuilt(CommonMethods.ExcelLib.ReadData(2, "YearBuilt"));
            OwnerOccupied();
            FileUpload(CommonMethods.ExcelLib.ReadData(2, "FilePath"));
        }

        //Check the page
        public void VerifyPropertyDetailsPage()
        {
            try
            {
                Driver.WaitForElementClickable(
                    By.XPath("//div[@class='center aligned column']//button[@class='ui teal button'][contains(text(),'Next')]"), 2);
                if (BtnNext.Displayed && BtnNext.Enabled)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,
                        "Property Detail Page testing Passed, Fill all the detail successfull");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                        "Property Detail Page testing Failed, Fill all the detail Unsuccessfull");
                }
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                    "Property Detail Page testing Failed, Fill all the detail Unsuccessfull",
                    e.Message);
            }
        }

        // Click Next
        internal FinancedetailsPage ClickNext()
        {
            while (!BtnNext.Displayed && BtnNext.Enabled)
            {
                Thread.Sleep(100);
            }

            // check the button is ok
            BtnNext.Click();
            return new FinancedetailsPage();
        }
    }
}