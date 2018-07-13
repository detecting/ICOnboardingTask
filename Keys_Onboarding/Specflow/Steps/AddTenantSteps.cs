using System;
using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using TechTalk.SpecFlow;

namespace Keys_Onboarding.Specflow.Steps
{
    [Binding]
    public class AddTenantSteps
    {
        [Given(@"Go to property Owner Page")]
        public void GivenGoToPropertyOwnerPage()
        {
            // Creates a toggle for the given test, adds all log events under it    
            Base.test = Base.extent.StartTest("Add Tenant and Verity it" + GetDateAndTime.GetTimeNow());
        }

        [Given(@"I Click add tenant by input proerty name")]
        public void GivenIClickAddTenantByInputProertyName()
        {
            //Now page is Dashboard, then go to PropertyOwnersPage
            PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
        }

        [When(@"I fill all the form of each page : AddTenantDashboard,liabilitiesDetailsPage,summaryPage and I submit")]
        public void WhenIFillAllTheFormOfEachPageAddTenantDashboardLiabilitiesDetailsPageSummaryPageAndISubmit()
        {
            PropertyOwnerPage propertyOwnerPage = new PropertyOwnerPage();
            //Click add tenant by input proerty name
            AddTenantDashboardPage addTenantDashboardPage =
                propertyOwnerPage.ClickAddTenantAccordingToPropertyName();
            //fill AddTenantDashboard detail
            addTenantDashboardPage.FillTheDetails();
            //verity this page 
            addTenantDashboardPage.VerifyTenantDetailsPage();
            //click next button and move to liabilitiesDetailsPage
            LiabilitiesDetailsPage liabilitiesDetailsPage = addTenantDashboardPage.ClickNext();
            //click next button and move to summaryPage
            SummaryPage summaryPage = liabilitiesDetailsPage.ClickNextBtn();
            //click submit button and move to PropertyOwnerPage
            PropertyOwnerPage propertyOwnerPageAfterAddTenant = summaryPage.ClickSubmit();
        }

        [Then(@"the tenant is added")]
        public void ThenTheTenantIsAdded()
        {
            PropertyOwnerPage propertyOwnerPageAfterAddTenant = new PropertyOwnerPage();
            //verify if the tenant is added.
            propertyOwnerPageAfterAddTenant.VerifyAddTenant();
        }
    }
}