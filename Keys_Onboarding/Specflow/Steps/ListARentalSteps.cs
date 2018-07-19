using System;
using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using TechTalk.SpecFlow;

namespace Keys_Onboarding
{
    [Binding]
    public class ListARentalSteps
    {
        public ListARentalSteps()
        {
            // Creates a toggle for the given test, adds all log events under it    
            Base.test = Base.extent.StartTest("List A Rental and Verity it" + GetDateAndTime.GetTimeNow());
        }

        [Given(@"I navigate to the property Owner Page")]
        public void GivenGoToThePropertyOwnerPage()
        {
            //Now page is Dashboard, then go to PropertyOwnersPage
            PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
        }

        [Given(@"I click List Rental")]
        public void GivenIClickListRental()
        {
            PropertyOwnerPage propertyOwnerPage = new PropertyOwnerPage();

            //move to listRental Page
            ListRentalPage listRentalPage = propertyOwnerPage.ClickListRental();
        }

        [When(@"I fill the detail of ListRental Page and Click Save And Accept List Rental")]
        public void WhenIFillTheDetailOfListRentalPageAndClickSaveAndAcceptListRental()
        {
            //move to listRental Page
            ListRentalPage listRentalPage = new ListRentalPage();
            //Fill the detail of ListRental Page
            listRentalPage.FillTheDetails();
            //Verity ListRental Page
            listRentalPage.VerfyListRentalPage();
            //Save and Confirm list Rental
            RentalPropertiesPage rentalPropertiesPage = listRentalPage.ClickSaveAndAcceptListRental();
        }

        [Then(@"The Rental should be listed")]
        public void ThenTheRentalShouldBeListed()
        {
            RentalPropertiesPage rentalPropertiesPage = new RentalPropertiesPage();
            //check the result 
            rentalPropertiesPage.CheckRentalWhichAdded();
        }
    }
}