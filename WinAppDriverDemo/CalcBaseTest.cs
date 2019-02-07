using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using NUnit.Framework;

namespace WinAppDriverDemo
{
    [TestFixture]
    public class CalcBaseTest
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        private static WindowsDriver<WindowsElement> calcSession;

        [SetUp]
        public void Precondition()
        {
            DesiredCapabilities desktopCapabilities = new DesiredCapabilities();
            desktopCapabilities.SetCapability("app", CalculatorAppId);
            desktopCapabilities.SetCapability("deviceName", "WindowsPC");
            calcSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), desktopCapabilities);
            
            calcSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
        }

        [TearDown]
        public void Teardown()
        {
            if (calcSession != null)
            {
                calcSession.Quit();
            }
        }

        [Test]
        public void CheckUiExist()
        {
            Assert.NotNull(calcSession.FindElementsByName("Calculator"), "Calc does NOT exist");
        }
    }
}
