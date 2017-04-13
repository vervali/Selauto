using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Threading;
using AventStack.ExtentReports.Reporter.Configuration;
using System.IO;
using NUnit.Framework.Interfaces;

namespace CoreHrTest.Reporting
{
   public class SetupTearDown
    {
        public string testname;
        public ExtentTest test;
        public ExtentReports rep;
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            rep = ExtentManger.Instance;
        }

        [SetUp]
        public void Setup()
        {
            testname = TestContext.CurrentContext.Test.Name;
            test = rep.CreateTest(testname);
            //testname = testname.Remove(testname.IndexOf('('), testname.Length - testname.IndexOf('('));
            test.Log(Status.Info, "Starting test" + testname + "...");
        }
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                test.Log(Status.Fail, "Ending the test :" + testname);
                test.Log(Status.Fail, "StackTrace" + stackTrace);
                test.Log(Status.Fail, "Error Message : " + errorMessage);

            }

            else
            {
                test.Log(Status.Pass, "Test Passed : " + testname);
            }

        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            rep.Flush();
        }

        public class ExtentManger
        {
            public static string rootFolder = Directory.GetCurrentDirectory();
            public static readonly ExtentReports _instance = new ExtentReports();
            public static ExtentReports _flush = new ExtentReports();
            public static string testReportsFolderPath = rootFolder + "\\TestReports";
            public static string reportsfolderPath = testReportsFolderPath + "\\" + DateTime.Today.ToString("yyyy-MM-dd");
            public static string reportsTimePath = reportsfolderPath + "\\" + DateTime.UtcNow.ToString("hh-mm-ss-ff");
            public static string filePathAndName = reportsTimePath + "\\Reports.html";

            static ExtentManger()
            {
                if (!Directory.Exists(testReportsFolderPath))
                {
                    Directory.CreateDirectory(testReportsFolderPath);
                }
                if (!Directory.Exists(reportsfolderPath))
                {
                    Directory.CreateDirectory(reportsfolderPath);
                }
                if (!Directory.Exists(reportsTimePath))
                {
                    Directory.CreateDirectory(reportsTimePath);
                }
                var htmlReporter = new ExtentHtmlReporter(filePathAndName);
                htmlReporter.LoadConfig(rootFolder + "\\packages\\ExtentReports.3.0.1\\lib\\extent-config.xml");
                Instance.AttachReporter(htmlReporter);
            }

           
            public static ExtentReports Instance
            {
                get
                {
                    return _instance;
                }
            }
            private void ExtentManager() { }

        }
        public class ExtentTestManager
        {
            public static ThreadLocal<ExtentTest> _test;
            public static ExtentReports _extent = ExtentManger.Instance;


            public static ExtentTest GetTest()
            {
                return _test.Value;
            }

            public static ExtentTest CreateTest(string name)
            {
                if (_test == null)
                    _test = new ThreadLocal<ExtentTest>();
                var t = _extent.CreateTest(name);
                _test.Value = t;
                return t;
            }


            public static ExtentHtmlReporter getHtmlReporter()
            {
                var htmlReporter = new ExtentHtmlReporter(ExtentManger.filePathAndName);
                htmlReporter.Configuration().ChartVisibilityOnOpen = true;
                string documentTitle = "CoreHr Reports";
                string encoding = "UTF-8";
                string reportName = "Corehr Automation Reorts";
                htmlReporter.Configuration().DocumentTitle = documentTitle;
                htmlReporter.Configuration().Encoding = encoding;
                htmlReporter.Configuration().Theme = Theme.Dark;
                htmlReporter.Configuration().ReportName = reportName;
                //htmlReporter.LoadConfig("E:\\CHR\\CorehrAut\\packages\\ExtentReports.3.0.0\\lib\\extent-config.xml");

                return htmlReporter;
            }
        }
    }

}
