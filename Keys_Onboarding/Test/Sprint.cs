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
            [Test]
            public void PO_AddNewProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property"+GetDateAndTime.GetTimeNow());
                // After Login and the goto Dashboard Page
                DashboardPage dashboardPage = new DashboardPage();
                // Create an class and object to call the method
                PropertyOwnerPage propertyOwnerPage = dashboardPage.PropertyOwners();
                //Search the property
                propertyOwnerPage.SearchAProperty();
            }
        }
    }
}