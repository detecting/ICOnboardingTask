using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys_Onboarding.Global;

namespace Keys_Onboarding.Pages
{
    public class BasePage
    {
        /// <summary>
        /// global wait
        /// </summary>
        public BasePage()
        {
            Driver.wait(10);
        }
    }
}
