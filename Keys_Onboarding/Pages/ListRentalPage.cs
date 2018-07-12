using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[2]/select[1]")]
        IWebElement DdlSelectePropeties { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[1]/input[1]")]
        IWebElement InputTitle { get; set; }

        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[2]/textarea[1]")]
        IWebElement TextareaDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[3]/div[1]/input[2]")]
        IWebElement InputMovingCost { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[4]/div[1]/input[1]")]
        IWebElement InputTargetRent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[4]/div[2]/input[1]")]
        IWebElement InputFurnishing { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[1]/input[1]")]
        IWebElement InputAvailableDate { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[5]/div[2]/input[1]")]
        IWebElement InputIdealTenant { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[6]/div[1]/input[1]")]
        IWebElement InputOccupantCount { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[1]/div[6]/div[2]/select[1]")]
        IWebElement PetsAllowedOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='file-upload']")]
        IWebElement BtnfilesUpload { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='teal ui button']")]
        IWebElement BtnSave { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class=\'btnSeccion ui button\']")]
        private IWebElement BtnCancel { get; set; }

        #endregion

        #region page methods

        

        #endregion
    }
}