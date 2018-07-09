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
    class AddNewPropertyPage : BasePage
    {
        public AddNewPropertyPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Define Elements

        // Define PropertyName input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[2]/div[1]/div[1]/input[1]")]
        IWebElement InputPropertyName { get; set; }

        // Define PropertyType DDL
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[2]/div[2]/div[1]")]
        IWebElement DpdPropertyType { get; set; }

        // Define SearchAddress Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[3]/div[1]/div[1]/input[1]")]
        IWebElement InputSearchAddress { get; set; }

        // Define Description Text
        [FindsBy(
            How = How.XPath,
            Using = "//html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[3]/div[2]/div[1]/textarea[1]")]
        IWebElement TextDescription { get; set; }

        // Define TargetRent Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[4]/div[1]/div[1]/div[1]/input[1]")]
        IWebElement InputTargetRent { get; set; }

        // Define RentType DDL
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[4]/div[1]/div[2]/div[1]")]
        IWebElement DdpRentType { get; set; }

        // Define LandArea Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[5]/div[1]/div[1]/input[1]")]
        IWebElement InputLandArea { get; set; }

        // Define FloorArea Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[5]/div[2]/div[1]/input[1]")]
        IWebElement InputFloorArea { get; set; }

        // Define Bedrooms Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[6]/div[1]/div[1]/input[1]")]
        IWebElement InputBedrooms { get; set; }

        // Define Bathrooms Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[6]/div[2]/div[1]/input[1]")]
        IWebElement InputBathrooms { get; set; }

        // Define CarPark Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[7]/div[1]/div[1]/input[1]")]
        IWebElement InputCarparks { get; set; }

        // Define YearBuit Input
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[7]/div[2]/div[1]/input[1]")]
        IWebElement InputYearBuilt { get; set; }

        // Define OwnerOccupied Check Box
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[8]/div[1]/input[1]")]
        IWebElement CBOwnerOccupied { get; set; }

        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[9]/div[2]/div[1]/input[1]")]
        IWebElement FileUploadBtn { get; set; }

        //Define Next button
        [FindsBy(
            How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[10]/div[1]/button[1]")]
        IWebElement BtnNext { get; set; }

        #endregion

        //Fill propertyName
        internal void PropertyName(string propertyName)
        {
            InputPropertyName.Clear();
            InputPropertyName.SendKeys(propertyName);
        }

        // Fill propertyType
        internal void PropertyType(string propertyType)
        {
            // click the PropertyType
            DpdPropertyType.Click();

            // wait fot the lsit to show up
            IWebElement listPropertyType = Driver.WaitForElementExist(
                By.XPath("/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[2]/div[2]/div[1]/div[2]"), 5);
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
        internal void SearchAddress(string searchAddress)
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
        internal void Description(string description)
        {
            TextDescription.Clear();
            TextDescription.SendKeys(description);
        }

        // Fill targetRent
        internal void TargetRent(string targetRent)
        {
            InputTargetRent.Clear();
            InputTargetRent.SendKeys(targetRent);
        }

        // Fill rentType
        internal void RentType(string rentType)
        {
            DdpRentType.Click();
            IWebElement listsDdpRentType = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(5)).Until(
                ExpectedConditions.ElementExists(
                    By.XPath(
                        "/html[1]/body[1]/div[2]/section[1]/form[1]/fieldset[1]/div[4]/div[1]/div[2]/div[1]/div[2]")));
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
        internal void LandArea(string landArea)
        {
            InputLandArea.Clear();
            InputLandArea.SendKeys(landArea);
        }

        // Fill floorArea
        internal void FloorArea(string floorArea)
        {
            InputFloorArea.Clear();
            InputFloorArea.SendKeys(floorArea);
        }

        // Fill bedrooms
        internal void Bedrooms(string bedrooms)
        {
            InputBedrooms.Clear();
            InputBedrooms.SendKeys(bedrooms);
        }

        // Fill bathrooms
        internal void Bathrooms(string bathrooms)
        {
            InputBathrooms.Clear();
            InputBathrooms.SendKeys(bathrooms);
        }

        // Fill carparks
        internal void Carparks(string carparks)
        {
            InputCarparks.Clear();
            InputCarparks.SendKeys(carparks);
        }

        // Fill yearBuilt
        internal void YearBuilt(string yearBuilt)
        {
            InputYearBuilt.Clear();
            InputYearBuilt.SendKeys(yearBuilt);
        }

        // Tick  OwnerOccupied
        internal void OwnerOccupied()
        {
            Thread.Sleep(1000);
            CBOwnerOccupied.Click();
            Thread.Sleep(1000);
        }

        //File Upload
        internal void FileUpload(string filePath)
        {
            FileUploadBtn.SendKeys(filePath);
        }

        public void FillAllFieldsWithoutTickOwnerOccupied(string propertyName, string propertyType, string
                searchAddress, string description, string targetRent, string rentType, string landArea,
            string floorArea,
            string bedrooms, string bathrooms, string carparks, string yearBuilt, string filePath)
        {
            PropertyName(propertyName);
            PropertyType(propertyType);
            SearchAddress(searchAddress);
            Description(description);
            TargetRent(targetRent);
            RentType(rentType);
            LandArea(landArea);
            FloorArea(floorArea);
            Bedrooms(bedrooms);
            Bathrooms(bathrooms);
            Carparks(carparks);
            YearBuilt(yearBuilt);
            FileUpload(filePath);
        }

        public void FillAllFields(string propertyName, string propertyType, string
                searchAddress, string description, string targetRent, string rentType, string landArea,
            string floorArea,
            string bedrooms, string bathrooms, string carparks, string yearBuilt, string filePath)
        {
            PropertyName(propertyName);
            PropertyType(propertyType);
            SearchAddress(searchAddress);
            Description(description);
            TargetRent(targetRent);
            RentType(rentType);
            LandArea(landArea);
            FloorArea(floorArea);
            Bedrooms(bedrooms);
            Bathrooms(bathrooms);
            Carparks(carparks);
            YearBuilt(yearBuilt);
            OwnerOccupied();
            FileUpload(filePath);
        }

        // Click Next
        internal FinancedetailsPage Next()
        {
            // check the button is ok
            if (BtnNext.Displayed && BtnNext.Enabled)
            {
                BtnNext.Click();
                return new FinancedetailsPage();
            }

            return null;
        }
    }
}