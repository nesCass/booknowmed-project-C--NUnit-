using booknowmed.src.pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booknowmed.src.tests
{
	[TestFixture]
	public class LoginTest : BaseTest
	{

		[Test]
		public void FirstTest()
		{
			LoginPage loginPage = new LoginPage(this.driver, this.wait);
			MessagesPage messagesPage = new MessagesPage(this.driver, this.wait);

			this.driver.Navigate().GoToUrl(this.baseUrl + "/dialysis/login");

			loginPage.ClickOnCloseBtn();

			var displayed = messagesPage.IsTitleDisplayed();

			Assert.IsFalse(displayed, "Close button is not working");
		}
	}
}
