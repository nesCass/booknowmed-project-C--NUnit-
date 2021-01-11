using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booknowmed.src.pages
{
	internal class LogoutPage : BasePage
	{
		public LogoutPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
		{
		}


		public void UserLogout()
		{
			//System.Threading.Thread.Sleep(2000);

			this.driver.ExecuteJavaScript("arguments[0].click();", this.GetProfile());
			this.driver.ExecuteJavaScript("arguments[0].click();", this.GetLogoutBtn());

		}



		//getters
		public IWebElement GetProfile()
		{
			return this.driver.FindElement(By.XPath("//span[@class='display-name']"));
		}


		public IWebElement GetLogoutBtn()
		{
			return this.driver.FindElement(By.XPath("//button[normalize-space()='Log out']"));
		}


	}

}
