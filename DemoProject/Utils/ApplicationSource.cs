namespace DemoProject.Utils
{
    public class ApplicationSource
    {
        // Browser Data
        public string BrowserName { get; private set; }

        // Implicit and Explicit Waits
        public long ImplicitWaitTimeOut { get; private set; }
        public long ExplicitTimeOut { get; private set; }

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
