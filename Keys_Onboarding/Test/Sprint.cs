using Keys_Onboarding.Global;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys_Onboarding.Pages;
using OpenQA.Selenium;

namespace Keys_Onboarding.Test
{
    class Sprint
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Base
        {
            [Test, Description("Nunit-Search for a property!")]
            public void SearchAProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property" + GetDateAndTime.GetTimeNow());
                // After Login and the goto Dashboard Page
                DashboardPage dashboardPage = new DashboardPage();
                // Create an class and object to call the method
                PropertyOwnerPage propertyOwnerPage = dashboardPage.GotoPropertyOwnersPage();
                //Search the property
                propertyOwnerPage.SearchAProperty();
            }

            [Test, Order(1), Description("Nunit-Create New Property and Verify it!")]
            public void CreateNewProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Create new property and Verity it" + GetDateAndTime.GetTimeNow());
                //Now page is Dashboard, then go to PropertyOwnersPage
                PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();

                AddNewPropertyPage addNewPropertyPage = propertyOwnerPage.ClickAddNewPropertyBtn();
                //Fill details of AddNewProperty Page.
                addNewPropertyPage.FillAllFieldsWithoutTickOwnerOccupied();
                //Verify addNewPropertyPage 
                addNewPropertyPage.VerifyPropertyDetailsPage();
                
                //Click Next button and move to financedetailsPage
                FinancedetailsPage financedetailsPage = addNewPropertyPage.ClickNext();
                //Fill the detail 
                financedetailsPage.FillFinanceDetailsPage();
                //Add repayment
                financedetailsPage.FillAddRepayment();
                //Verify Finance Detail Page
                financedetailsPage.VerifyFinanceDetailsPage();

                //Goto to Tenant Detail Page
                TenantDetailsPage tenantDetailsPage = financedetailsPage.ClickNext();
                // fill the data of tenantDetailsPage
                tenantDetailsPage.FillTheDetails();
                // verify tenantDetailsPage 
                tenantDetailsPage.VerifyTenantDetailsPage();
                // Click save button
                PropertyOwnerPage propertyOwnerPage_SavedNewPro = tenantDetailsPage.ClickSave();
                // Verify the result
                propertyOwnerPage_SavedNewPro.SearchPropertiesWhichAdded();
            }

            [Test, Order(2), Description("Nunit-List A Rental and Verity it")]
            public void ListARntial()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("List A Rental and Verity it" + GetDateAndTime.GetTimeNow());
                //Now page is Dashboard, then go to PropertyOwnersPage
                PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
            }
        }
    }
}