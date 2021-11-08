using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Utils
{
    public class ApplicationSource
    {
        // Browser Data
        public string BrowserName { get; private set; }

        // Implicit and Explicit Waits
        public long ImplicitWaitTimeOut { get; private set; }
        public long ExplicitTimeOut { get; private set; }

        //Database Connection
        public string DatabaseUrl { get; private set; }
        public string DatabaseLogin { get; private set; }
        public string DatabasePassword { get; private set; }

        // TODO Develop Builder
        public ApplicationSource(string browserName,
                long implicitWaitTimeOut,
                long explicitTimeOut)
        {
            this.BrowserName = browserName;
            this.ImplicitWaitTimeOut = implicitWaitTimeOut;
            this.ExplicitTimeOut = explicitTimeOut;
        }

    }
}
