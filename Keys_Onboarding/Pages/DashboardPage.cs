using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys_Onboarding.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        //Define Owners tab 
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]")]
        private IWebElement Owners { set; get; }

        // Find Owner List
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]")]
        IWebElement OwnerList { get; set; }

        //Define Properties page
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]")]
        private IWebElement Properties { set; get; }

        public PropertyOwnerPage PropertyOwners()
        {
            Thread.Sleep(1000);
            // Wait for Owner to be clickable
            Driver.WaitForElementClickable(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/i[1]"), 5);
            Owners.Click();

            //Waiting for OwnerList to be displayed
            Driver.WaitForElementExist(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]"), 5);
            // Select Properties
            Properties.Click();
            // Return to PropertyOwnerPage
            return new PropertyOwnerPage();
        }
    }
}