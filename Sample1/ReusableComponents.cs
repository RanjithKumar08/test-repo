using System;
using System.Collections.Generic;
using System.Data;
using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Data.OleDb;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample1
{
    class ReusableComponents
    {
        public IWebElement Ielement;
        public IWebDriver driver;
        public static string Screenshot_folder = @"C:\Users\Ranjith\Desktop\VS\Sample1\SSFolder\";
        public static string htmlFolder = @"C:\Users\Ranjith\Desktop\sample\";
        public static string RunID = @"Run_1904.html";
        public static string htmlpath = "";
        public static string scrnPath = "";


        //public IWebDriver driver;


        public void captureScreenshot(string imagename)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            scrnPath = Screenshot_folder + imagename + ".png";
            ss.SaveAsFile(scrnPath, ScreenshotImageFormat.Png);
        }



        public void ClickElementByID()
        {
            Thread.Sleep(1000);
            //if (driver.FindElement(By.ClassName("_2zrpKA _1dBPDZ")).Displayed)
            if (driver.FindElement(By.Id("gsc-i-id1")).Displayed)
            {
                //IWebElement button1 = driver.FindElement(By.Id("gsc-i-id1"));
                //button1.SendKeys("testing");
                driver.FindElement(By.Id("gsc-i-id1")).SendKeys("testing");
                captureScreenshot("image1");
                driver.Navigate().GoToUrl("http://www.amazon.com");
                captureScreenshot("image2");
                // Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                //ss.SaveAsFile(@"C:\Users\Ranjith\Desktop\VS\Sample1\SSFolder\image.png", ScreenshotImageFormat.Png);

            }
            else
            {
                driver.Navigate().GoToUrl("http://www.google.com");
                Actions dummy = new Actions(driver);
                dummy.ClickAndHold();

            }
        }

        public void initializeData()
        {
            DataTable db = new DataTable();
            var dbconnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\Users\IIG\Desktop\test.xlsx;Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
            dbconnection.Open();
            OleDbCommand dbcmd = new OleDbCommand();
            dbcmd.Connection = dbconnection;
            dbcmd.CommandType = CommandType.Text;
            dbcmd.CommandText = "Select * from ";
        }

        public static string htmltext = "";
        public static int stepNumber = 1;
        public void htmlcreation()
        {
            htmlpath = htmlFolder + RunID;
            htmltext += @"</table></body></html>";
            File.WriteAllText(htmlpath, htmltext);
            
            //driver.Quit();
        }

        public void initializeHTMLReport()
        {
            htmltext = @"<!DOCTYPE html><html><body><h1>getha vidatha getha vidatha</h1>";
            htmltext += @"<p> Mass scenes </p>";
            htmltext += @"<table style=width:100%><tr><th>StepNumber</th><th>StepName</th><th>StepDescription</th><th>ActualResult</th>";
        }

        public void updateTestLog(string stepName, string stepDesc, String Result )
        {
            captureScreenshot("Image_Capture_" + stepNumber);
            htmltext += @"<tr align = center><td>" + stepNumber + "</td>" + "<td>" + stepName + "</td>" + "<td>" + stepDesc + "</td>" + "<td> <a href = "+scrnPath+">" + Result + "</a></td></tr>";
            stepNumber++;
         }

        public void dummypurpose()
        {
            Dictionary<Int64, string> dict = new Dictionary<Int64, string>();
            dict.Add(1, "one");
            dict.Add(2, "monkey");
            dict.Add(3, "donkey");
            dict.Add(4, "pambu");
            foreach (KeyValuePair<Int64, string> item in dict)
            {
                Console.WriteLine("key: - " + item.Key + "    value : -  " + item.Value);
            }
        }

        public void clicklinkbytext(string linkName, string linkdescription)
        {
            if (driver.FindElement(By.LinkText(linkName)).Displayed)
            {
                driver.FindElement(By.LinkText(linkName)).Click();
                captureScreenshot(linkdescription);
                updateTestLog("Clicking given Link", "Given link - " + linkdescription + " is clicked successfully.","Passed");

            }
            else
            {

            }

        }

        public void waitforelementtopresent(int TinSec)
        {

        }
        public void demoautomation()
        {

            clicklinkbytext("Selenium vs QTP", "QTP Link");


            //driver.FindElement(By.ClassName("btn btn-hero btns btn-success hero-right")).Click();
            //driver.FindElement(By.CssSelector()

            /*
             * if (driver.FindElement(By.ClassName("paddle_button wow fadeIn btn btn - primary btn - block web animated")).Displayed)
            {
                driver.Manage().Window.Minimize();
            }
            else
            {
                Thread.Sleep(5000);
            }
            */
            //driver.FindElement(By.ClassName("paddle_button wow fadeIn btn btn - primary btn - block web animated")).Click();

        }

        public void MethodIni1()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.javatpoint.com/selenium-tutorial");
            driver.Manage().Window.Maximize();
            //driver.FindElement(By.ClassName("button button-line brochure")).Click();
            Thread.Sleep(5000);
            //    Assert.IsTrue(driver.FindElement(By.LinkText("https://www.javatpoint.com")).Displayed);




            //driver.FindElement(By.LinkText("Selenium vs QTP")).Click();
            //Console.WriteLine("Testing");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("disable-infobars");
            captureScreenshot("image1");
            updateTestLog("Browser Launch", "Browser is launched successfully", "Passed");

        }
    }
}