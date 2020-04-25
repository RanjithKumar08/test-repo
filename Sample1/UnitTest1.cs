using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample1
{
    [TestClass]
    public class UnitTest1
    {
        ReusableComponents ActionLibrary = new ReusableComponents();

        public IWebElement Ielement { get; private set; }
        public IWebElement driver1;


        [TestInitialize]
        public void InitMethod()
        {
            ActionLibrary.initializeHTMLReport();
            ActionLibrary.MethodIni1();
            // ActionLibrary.dummypurpose();
            //ActionLibrary.initializeData();
        }

        [TestMethod]
        public void TC1()
        {
            ActionLibrary.demoautomation();
            //ActionLibrary.ClickElementByID();



            //r ActionLibrary.clicklinkbytext("/content/dam/icicipru/brochures/ICICI-Pru-iProtect-Smart-Illustrated-Brochure.pdf", "testing");
            //ActionLibrary.driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            //ActionLibrary.driver.SwitchTo().Window(ActionLibrary.driver.WindowHandles.Last());
            //ActionLibrary.driver.FindElement(By.ClassName("button button-line brochure")).SendKeys(Keys.Control+"t");
            //ActionLibrary.driver.Navigate().GoToUrl("www.amazon.com");
            //ActionLibrary.ClickElementByID();

        }

        [TestCleanup]
        public void wrapUpTest()
        {
            ActionLibrary.htmlcreation();

        }
    }
}
