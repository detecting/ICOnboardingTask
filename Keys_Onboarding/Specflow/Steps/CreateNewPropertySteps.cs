using System;
using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using TechTalk.SpecFlow;

namespace Keys_Onboarding.Specflow.Steps
{
    [Binding]
    public class CreateNewPropertySteps
    {
        public CreateNewPropertySteps()
        {
            // Creates a toggle for the given test, adds all log events under it    
            Base.test =
                Base.extent.StartTest("Create new property and Verity it" + GetDateAndTime.GetTimeNow());
        }

        [Given(@"Go to propertyOwner Page")]
        public void GivenGoToPropertyOwnerPageAnd()
        {
            //Now page is Dashboard, then go to PropertyOwnersPage
            PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
        }

        [Given(@"Click Add New Property button")]
        public void GivenClickAddNewPRopertyButton()
        {
            PropertyOwnerPage propertyOwnerPage = new PropertyOwnerPage();

            AddNewPropertyPage addNewPropertyPage = propertyOwnerPage.ClickAddNewPropertyBtn();
        }

        [When(
            @"I Fill all the forms of Property Details page, Finance details page and  tenant Details Page and click Save button")]
        public void WhenIFillAllTheFormsOfPropertyDetailsPageFinanceDetailsPageAndTenantDetailsPageAndClickSaveButton()
        {
            AddNewPropertyPage addNewPropertyPage = new AddNewPropertyPage();
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
            PropertyOwnerPage propertyOwnerPageSavedNewPro = tenantDetailsPage.ClickSave();
            
        }

        [Then(@"A new property should be created")]
        public void ThenANewPropertyShouldBeCreated()
        {
            PropertyOwnerPage propertyOwnerPageSavedNewPro=new PropertyOwnerPage();
            // Verify the result
            propertyOwnerPageSavedNewPro.SearchPropertiesWhichAdded();
        }
    }
}