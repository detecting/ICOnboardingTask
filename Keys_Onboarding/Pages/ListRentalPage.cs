using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys_Onboarding.Pages
{
    public class ListRentalPage : BasePage
    {
        public ListRentalPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region define elements

        //define SelectePropeties
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[2]/select[1]")]
        IWebElement DdlSelectePropeties { get; set; }

        //define Title
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[1]/input[1]")]
        IWebElement InputTitle { get; set; }

        //define Description
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[2]/textarea[1]")]
        IWebElement TextareaDescription { get; set; }

        //define MovingCost
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[1]/input[2]")]
        IWebElement InputMovingCost { get; set; }

        //define TargetRent
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[4]/div[1]/input[1]")]
        IWebElement InputTargetRent { get; set; }

        //define Furnishing
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[4]/div[2]/input[1]")]
        IWebElement InputFurnishing { get; set; }

        //define AvailableDate
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[1]/input[1]")]
        IWebElement InputAvailableDate { get; set; }

        //define IdealTenant 
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[2]/input[1]")]
        IWebElement InputIdealTenant { get; set; }

        //define OccupantCount
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[6]/div[1]/input[1]")]
        IWebElement InputOccupantCount { get; set; }

        //define PetsAllowedO
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[6]/div[2]/select[1]")]
        IWebElement PetsAllowedOption { get; set; }

        //define filesUpload
        [FindsBy(How = How.XPath, Using = "//input[@id='file-upload']")]
        IWebElement BtnfilesUpload { get; set; }

        //define Save
        [FindsBy(How = How.XPath, Using = "//button[@class='teal ui button']")]
        IWebElement BtnSave { get; set; }

        //define Cancel
        [FindsBy(How = How.XPath, Using = "//button[@class=\'btnSeccion ui button\']")]
        IWebElement BtnCancel { get; set; }

        #endregion

        #region page methods

        void SelectProperty(string selectProperty)
        {
            var lists = DdlSelectePropeties.FindElements(By.TagName("option"));
            foreach (var item in lists)
            {
                if (item.Text == selectProperty)
                {
                    item.Click();
                }
            }
        }

        void Title(string title)
        {
            InputTitle.Clear();
            InputTitle.SendKeys(title);
        }

        void Description(string description)
        {
            TextareaDescription.Clear();
            TextareaDescription.SendKeys(description);
        }

        void MovingCost(string movingCost)
        {
            InputMovingCost.Clear();
            InputMovingCost.SendKeys(movingCost);
        }

        void TargetRent(string targetRent)
        {
            InputTargetRent.Clear();
            InputTargetRent.SendKeys(targetRent);
        }

        void Furnishing(string furnishing)
        {
            InputFurnishing.Clear();
            InputFurnishing.SendKeys(furnishing);
        }

        void AvailableDate()
        {
//            InputAvailableDate.Clear();
            InputAvailableDate.SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        void IdealTenant(string idealTenant)
        {
            InputIdealTenant.Clear();
            InputIdealTenant.SendKeys(idealTenant);
        }

        void OccupantsCount(string occupantsCount)
        {
            InputOccupantCount.Clear();
            InputOccupantCount.SendKeys(occupantsCount);
        }

        void PetsAllowed(string petsAllowed)
        {
            var lists = PetsAllowedOption.FindElements(By.TagName("option"));
            foreach (var item in lists)
            {
                if (item.Text == petsAllowed)
                {
                    item.Click();
                }
            }
        }

        void FileUpload(string filePath)
        {
            BtnfilesUpload.SendKeys(filePath);
        }

        #endregion

        /// <summary>
        /// fill the form
        /// </summary>
        public void FillTheDetails()
        {
            CommonMethods.ExcelLib.PopulateInCollection(Base.ExcelPath, "ListRentalProperty");
            SelectProperty(CommonMethods.ExcelLib.ReadData(2, "SelectProperty"));
            Title(CommonMethods.ExcelLib.ReadData(2, "Title"));
            Description(CommonMethods.ExcelLib.ReadData(2, "Description"));
            MovingCost(CommonMethods.ExcelLib.ReadData(2, "MovingCost"));
            TargetRent(CommonMethods.ExcelLib.ReadData(2, "TargetRent"));
            Furnishing(CommonMethods.ExcelLib.ReadData(2, "Furnishing"));
            AvailableDate();
            IdealTenant(CommonMethods.ExcelLib.ReadData(2, "IdealTenant"));
            OccupantsCount(CommonMethods.ExcelLib.ReadData(2, "OccupantsCount"));
            PetsAllowed(CommonMethods.ExcelLib.ReadData(2, "PetsAllowed"));
            FileUpload(CommonMethods.ExcelLib.ReadData(2, "FilePath"));
        }

        /// <summary>
        /// verify Save button is clickable
        /// </summary>
        public void VerfyListRentalPage()
        {
            try
            {
                Driver.WaitForElementClickable(By.XPath("//button[@class='teal ui button']"), 3);
                if (BtnSave.Displayed && BtnSave.Enabled)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass,
                        "List Rental Page testing Passed, Fill the detail successfull");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                        "List Rental Page testing Failed, Fill the detail Unsuccessfull");
                }
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message);
            }
        }

        /// <summary>
        /// Save and accept 
        /// </summary>
        /// <returns></returns>
        public RentalPropertiesPage ClickSaveAndAcceptListRental()
        {
            while (!BtnSave.Displayed && BtnSave.Enabled)
            {
                Thread.Sleep(100);
            }

            BtnSave.Click();
            Driver.driver.SwitchTo().Alert().Accept();
            while (!Driver.driver.Url.Contains("RentalProperties"))
            {
                Thread.Sleep(100);
            }

            return new RentalPropertiesPage();
        }
    }
}