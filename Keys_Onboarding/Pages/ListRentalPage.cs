using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys_Onboarding.Global;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys_Onboarding.Pages
{
    public class ListRentalPage:BasePage
    {
        public ListRentalPage()
        {
            PageFactory.InitElements(Driver.driver,this);
        }

    }
}
