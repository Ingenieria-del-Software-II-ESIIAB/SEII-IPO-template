using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppForSEII.UIT.Shared
{
    public class UIC_UIT
    {
        private  bool _pipeline = false;
        //private  string _browser = "Chrome";
        //private  string _browser = "Firefox";
        private  string _browser = "Edge";
        public  string URIforUIT
        {
            get
            {
                return "https://localhost:7197/";

            }
        }

        public  void SetUp_UIT(out IWebDriver _driver, out string _URI)
        {
            switch (_browser)
            {
                case "Firefox":
                    SetUp_FireFox4UIT(out _driver);
                    break;
                case "Edge":
                    SetUp_EdgeFor4UIT(out _driver);
                    break;
                default:
                    //by default Chrome will be used
                    SetUp_Chrome4UIT(out _driver);
                    break;
            }
            //Added to make _Driver wait when an element is not found.
            //It will wait for a maximum of 50 seconds.


            _URI = URIforUIT;
            _driver.Manage().Window.Maximize();



        }

        public  void SetUp_Chrome4UIT(out IWebDriver _driver)
        {
            var optionsc = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                AcceptInsecureCertificates = true
            };
            //For pipelines use this option for hiding the browser
            if (_pipeline) optionsc.AddArgument("--headless");

            _driver = new ChromeDriver(optionsc);

        }

        public  void SetUp_FireFox4UIT(out IWebDriver _driver)
        {
            var optionsff = new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                AcceptInsecureCertificates = true
            };
            //For pipelines use this option for hiding the browser
            if (_pipeline) optionsff.AddArgument("--headless");

            _driver = new FirefoxDriver(optionsff);

        }

        public  void SetUp_EdgeFor4UIT(out IWebDriver _driver)
        {
            //var edgeDriverService = Microsoft.Edge.SeleniumTools.EdgeDriverService.CreateChromiumService();
            //var edgeOptions = new Microsoft.Edge.SeleniumTools.EdgeOptions();
            //edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            //edgeOptions.UseChromium = true;
            //if (_pipeline) edgeOptions.AddArguments("--headless");

            //_driver = new Microsoft.Edge.SeleniumTools.EdgeDriver(edgeDriverService, edgeOptions);

            var optionsEdge = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                AcceptInsecureCertificates = true
            };

            //For pipelines use this option for hiding the browser
            if (_pipeline) optionsEdge.AddArgument("--headless");

            _driver = new EdgeDriver(optionsEdge);

        }


        public  void WaitForBeingVisible(IWebDriver _driver, By IdElement)
        {
            //used whenever the webelement needs a delay for being clickable
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 10, 0));


            wait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                typeof(WebDriverTimeoutException),
                typeof(UnhandledAlertException),
                typeof(ElementClickInterceptedException));

            IWebElement visibleElement = wait.Until(d => 
            {
                try
                {
                    var el = _driver.FindElement(IdElement);
                    return el.Displayed ? el : null;
                }
                catch (NoSuchElementException)
                {
                    // Si el elemento aún no se ha creado en el DOM, devolvemos null para que siga intentando
                    return null; 
                }
            });
        }
    }
}
