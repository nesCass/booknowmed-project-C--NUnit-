using booknowmed.src.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace booknowmed.src.tests
{
	[TestFixture]
	public class LoginTest : BaseTest
	{
		[Test, Description("successfully logging with and without the \"Remember me\"")]
		[TestCase("ivicanklc@gmail.com", "qwerty1234", false)]
		[TestCase("ivicanklc@gmail.com", "qwerty1234", true)]
		public void SuccessfulLogin(string email, string password, bool remember)
		{

			LoginPage loginPage = new LoginPage(this.driver, this.wait);
			MessagesPage messagesPage = new MessagesPage(this.driver, this.wait);
			LogoutPage logoutPage = new LogoutPage(this.driver, this.wait);

			this.driver.Navigate().GoToUrl(this.baseUrl + "/dialysis/login");

			loginPage.LoginUser(email, password, remember);


			Assert.AreEqual(true, messagesPage.GetSuccessMessage());


			logoutPage.UserLogout();
		}



		[Test, Description("Checking the close button on login form")]
		public void FirstTest()
		{
			LoginPage loginPage = new LoginPage(this.driver, this.wait);
			MessagesPage messagesPage = new MessagesPage(this.driver, this.wait);

			this.driver.Navigate().GoToUrl(this.baseUrl + "/dialysis/login");

			loginPage.ClickOnCloseBtn();

			var displayed = messagesPage.IsTitleDisplayed();

			Assert.IsFalse(displayed, "Close button is not working");
		}





		[Test, Description("Checking bad links on login form")]
		public void BrokenLinksTest()
		{
			LoginPage loginPage = new LoginPage(this.driver, this.wait);

			this.driver.Navigate().GoToUrl(this.baseUrl + "/dialysis/login");

			var anchorElements = loginPage.GetAllAnchorElements();

			var broken = BrokenLinks(anchorElements);

			Assert.AreEqual(0, broken);
		}

		public static int VerifyURLStatus(string urlString)
		{
			int status = 0;
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlString);
				request.Method = "GET";
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				status = (int)response.StatusCode;
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
			}
			return status;
		}

		public static int BrokenLinks(ReadOnlyCollection<IWebElement> anchorElements)
		{
			int count = 0;

			foreach (IWebElement webElement in anchorElements)
			{
				string link = webElement.GetAttribute("href");
				Console.WriteLine("Link:  " + link);

				count = VerifyURLStatus(link) == 200 ? count : count + 1;
			}
			return count;
		}
	}
}

