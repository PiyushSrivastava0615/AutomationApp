using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TestProject
{

    class ExtentManager
    {



        private static ExtentReports extent;
        private static String fileName = "myReport.html";
        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                string dir = Path.Combine(Environment.CurrentDirectory, "Result", DateTime.Now.ToShortDateString());
                extent = createInstance(Path.Combine(dir + "\\ExtentReports.html"));
            }
            return extent;
        }



        private static ExtentReports createInstance(String fileName)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(fileName);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = fileName;
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.ReportName = fileName;
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            return extent;
        }
    }
}