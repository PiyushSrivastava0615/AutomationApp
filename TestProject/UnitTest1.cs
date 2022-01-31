using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        ExtentTest test;

        [TestInitialize]
        public void TestInit()
        {



            try
            {
                ChromeOptions options = new ChromeOptions();
                driver = new ChromeDriver();




                //driver.Navigate().GoToUrl("www.google.com");
            }
            catch (Exception ex)
            {



                Console.WriteLine(ex.Message);
            }

        }

        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

        [TestMethod]
        public void CheckReport()
        {
            ExtentReports reports = ExtentManager.getInstance();
            test = reports.CreateTest("myTest");




            driver.Navigate().GoToUrl("http://www.msn.com");
            System.Threading.Thread.Sleep(1000);
            var link = driver.FindElement(By.XPath("//span[@class='mectrlname mectrlsignin']"));
            link.Click();
            System.Threading.Thread.Sleep(3000);
            var aa = Capture(driver, "test1");
            test.Log(Status.Pass, "Screenshot 1 " + test.AddScreenCaptureFromPath(aa));
            System.Threading.Thread.Sleep(1000);

            test.Log(Status.Pass, "Test message");
            test.Log(Status.Fail, "Fail");
            aa = Capture(driver, "test 2");
            test.Log(Status.Pass, "Screenshot 2 " + test.AddScreenCaptureFromPath(aa));
            //test.AddScreenCaptureFromPath(aa);
            reports.Flush();
            //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("test.jpg");
            //testcontex


        }
    }
}