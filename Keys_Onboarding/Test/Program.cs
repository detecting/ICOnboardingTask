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
        class Mars : Base
        {
            [Test, Description("Nunit-Delete listings")]
            public void DeleteListing()
            {

            }

//            [Test, Description("Nunit-Search for a property!")]
//            public void SearchAProperty()
//            {
//                // Creates a toggle for the given test, adds all log events under it    
//                test = extent.StartTest("Search for a Property" + GetDateAndTime.GetTimeNow());
//                // After Login and the goto Dashboard Page
//                DashboardPage dashboardPage = new DashboardPage();
//                // Create an class and object to call the method
//                PropertyOwnerPage propertyOwnerPage = dashboardPage.GotoPropertyOwnersPage();
//                //Search the property
//                propertyOwnerPage.SearchAProperty();
//            }
//
//            [Test, Order(1), Description("Nunit-Create New Property and Verify it!")]
//            public void CreateNewProperty()
//            {
//                // Creates a toggle for the given test, adds all log events under it    
//                test = extent.StartTest("Create new property and Verity it" + GetDateAndTime.GetTimeNow());
//                //Now page is Dashboard, then go to PropertyOwnersPage
//                PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
//
//                AddNewPropertyPage addNewPropertyPage = propertyOwnerPage.ClickAddNewPropertyBtn();
//                //Fill details of AddNewProperty Page.
//                addNewPropertyPage.FillAllFieldsWithoutTickOwnerOccupied();
//                //Verify addNewPropertyPage 
//                addNewPropertyPage.VerifyPropertyDetailsPage();
//
//                //Click Next button and move to financedetailsPage
//                FinancedetailsPage financedetailsPage = addNewPropertyPage.ClickNext();
//                //Fill the detail 
//                financedetailsPage.FillFinanceDetailsPage();
//                //Add repayment
//                financedetailsPage.FillAddRepayment();
//                //Verify Finance Detail Page
//                financedetailsPage.VerifyFinanceDetailsPage();
//
//                //Goto to Mars Detail Page
//                TenantDetailsPage tenantDetailsPage = financedetailsPage.ClickNext();
//                // fill the data of tenantDetailsPage
//                tenantDetailsPage.FillTheDetails();
//                // verify tenantDetailsPage 
//                tenantDetailsPage.VerifyTenantDetailsPage();
//                // Click save button
//                PropertyOwnerPage propertyOwnerPageSavedNewPro = tenantDetailsPage.ClickSave();
//                // Verify the result
//                propertyOwnerPageSavedNewPro.SearchPropertiesWhichAdded();
//            }
//
//            [Test, Order(2), Description("Nunit-List A Rental and Verity it")]
//            public void ListARental()
//            {
//                // Creates a toggle for the given test, adds all log events under it    
//                test = extent.StartTest("List A Rental and Verity it" + GetDateAndTime.GetTimeNow());
//                //Now page is Dashboard, then go to PropertyOwnersPage
//                PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
//
//                //move to listRental Page
//                ListRentalPage listRentalPage = propertyOwnerPage.ClickListRental();
//                //Fill the detail of ListRental Page
//                listRentalPage.FillTheDetails();
//                //Verity ListRental Page
//                listRentalPage.VerfyListRentalPage();
//                //Save and Confirm list Rental
//                RentalPropertiesPage rentalPropertiesPage = listRentalPage.ClickSaveAndAcceptListRental();
//                //check the result 
//                rentalPropertiesPage.CheckRentalWhichAdded();
//            }
//
//            [Test, Order(3), Description("Nunit-Add Mars and Verify it")]
//            public void AddTenant()
//            {
//                // Creates a toggle for the given test, adds all log events under it    
//                test = extent.StartTest("Add Mars and Verity it" + GetDateAndTime.GetTimeNow());
//                //Now page is Dashboard, then go to PropertyOwnersPage
//                PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
//                    //Click add tenant by input proerty name
//                AddTenantDashboardPage addTenantDashboardPage =
//                    propertyOwnerPage.ClickAddTenantAccordingToPropertyName();
//                //fill AddTenantDashboard detail
//                addTenantDashboardPage.FillTheDetails();
//                //verity this page 
//                addTenantDashboardPage.VerifyTenantDetailsPage();
//                //click next button and move to liabilitiesDetailsPage
//                LiabilitiesDetailsPage liabilitiesDetailsPage = addTenantDashboardPage.ClickNext();
//                //click next button and move to summaryPage
//                SummaryPage summaryPage = liabilitiesDetailsPage.ClickNextBtn();
//                //click submit button and move to PropertyOwnerPage
//                PropertyOwnerPage propertyOwnerPageAfterAddTenant = summaryPage.ClickSubmit();
//                //verify if the tenant is added.
//                propertyOwnerPageAfterAddTenant.VerifyAddTenant();
//
//            }
        }
    }
}