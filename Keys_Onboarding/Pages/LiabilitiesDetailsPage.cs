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
    public class LiabilitiesDetailsPage : BasePage
    {
        public LiabilitiesDetailsPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region define elements

        //define previous button
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[2]/div[2]/div[1]/button[1]")]
        IWebElement BtnPrevious { get; set; }

        //define Next button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),\'Next\')]")]
        IWebElement BtnNext { get; set; }

        //define cancel button
        [FindsBy(How = How.XPath, Using = "//fieldset[@id='LiabilityDetail']//input[@class='ui button']")]
        IWebElement BtnCancel { get; set; }

        //define add new liability
        [FindsBy(How = How.XPath, Using = "//i[@class='plus circle icon']")]
        IWebElement BtnAddNewLiability { get; set; }

        #endregion

        #region page methods
        //click next and go to SummaryPage
        public SummaryPage ClickNextBtn()
        {
            while (!BtnNext.Displayed && BtnNext.Enabled)
            {
                Thread.Sleep(100);
            }

            BtnNext.Click();
            return new SummaryPage();
        }

        #endregion
    }
}