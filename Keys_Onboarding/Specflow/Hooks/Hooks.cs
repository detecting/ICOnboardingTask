using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys_Onboarding.Config;
using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;

namespace Keys_Onboarding.Specflow.Hooks
{
    [Binding]
    public class Hooks : Base
    {
        
        [BeforeScenario]
        public void Inititalize_specflow()
        {
            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {
                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
            }

            if (Keys_Resource.IsLogin == "true")
            {
                LoginPage loginobj = new LoginPage();
                // Go to DashboardPage
                loginobj.LoginSuccessfull();
            }
            else
            {
                Register obj = new Register();
                obj.Navigateregister();
            }

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(Keys_Resource.ReportXMLPath);
        }


        [AfterScenario]
        public void TearDown_specflow()
        {
            // Screenshot
            String img =
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver,
                    "Report"); //AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)            
            Driver.driver.Close();
        }   

    }
}