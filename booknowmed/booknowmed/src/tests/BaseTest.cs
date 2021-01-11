using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booknowmed.src.tests
{
	[TestFixture]
	public abstract class BaseTest
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;
		protected string baseUrl = "https://bnm.neopixdev.com";


		[OneTimeSetUp]
		public void SetUp()
		{
			this.driver = new FirefoxDriver();
			this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
			this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
			this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			this.driver.Manage().Window.Maximize();
		}


		[TearDown]
		public void AfterMethod()
		{
			if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
			{
				var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
				screenshot.SaveAsFile(@"C:\Users\ivica\Desktop\RODJENDAN\booknowmed-project-C--NUnit-\Screenshot.jpg");
			}
			this.driver.Manage().Cookies.DeleteAllCookies();
			this.driver.Navigate().Refresh();
		}


		[OneTimeTearDown]
		public void TearDown()
		{
			this.driver.Quit();
		}
	}
}
