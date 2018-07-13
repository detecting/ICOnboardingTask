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
    public class SummaryPage : BasePage
    {
        public SummaryPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region define elements

        //define previous button 
        [FindsBy(How = How.XPath,
            Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/fieldset[3]/div[10]/div[1]/button[1]")]
        public IWebElement BtnPrevious { get; set; }

        //define submit button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),\'Submit\')]")]
        public IWebElement BtnSubmit { get; set; }

        //define cancel button
        [FindsBy(How = How.XPath, Using = "//fieldset[@id=\'SummaryDetail\']//input[@class=\'ui button\']")]
        public IWebElement BtnCancel { get; set; }

        #endregion

        #region page methods

        public PropertyOwnerPage ClickSubmit()
        {
            while (!BtnSubmit.Displayed && BtnSubmit.Enabled)
            {
                Thread.Sleep(100);
            }

            BtnSubmit.Click();
            while (!Driver.driver.Url.Contains("Home/Index"))
            {
                Thread.Sleep(100);
            }
            return new PropertyOwnerPage();
        }

        #endregion
    }
}