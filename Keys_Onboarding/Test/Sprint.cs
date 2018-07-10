using Keys_Onboarding.Global;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys_Onboarding.Pages;

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

            [Test, Order(1), Description("Nunit-Fill the Property Details!")]
            public void CreateNewProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Create new property" + GetDateAndTime.GetTimeNow());
                //Now page is Dashboard, then go to PropertyOwnersPage
                PropertyOwnerPage propertyOwnerPage = new DashboardPage().GotoPropertyOwnersPage();
                AddNewPropertyPage addNewPropertyPage = propertyOwnerPage.ClickAddNewPropertyBtn();
                //Fill details of AddNewProperty Page.
                addNewPropertyPage.FillAllFieldsWithoutTickOwnerOccupied();
            }
        }
    }
}