using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booknowmed.src.pages
{
	public class MessagesPage : BasePage
	{
		public MessagesPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
		{
		}




		//getters

		public IWebElement GetEmailValidationMsg()
		{
			return this.driver.FindElement(By.XPath("//bnm-validation[text()='Email is required.']"));
		}


		public IWebElement GetPasswordValidationMsg()
		{
			return this.driver.FindElement(By.XPath("//bnm-validation[text()='Password is required.']"));
		}

		public IWebElement GetInvalidCombinationMsg()
		{
			return this.driver.FindElement(By.XPath("//bnm-validation[text()='Invalid email/password combination.']"));
		}

	}
}
