using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booknowmed.src.pages
{
	public class LoginPage : BasePage
	{
		public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
		{
		}

		public void LoginUser(string email = null, string password = null, bool remember = true)
		{
			this.GetEmailAddress()?.Clear();
			this.GetEmailAddress()?.SendKeys(email);
			this.GetPassword()?.Clear();
			this.GetPassword()?.SendKeys(password);

			if (!remember)
			{
				this.GetRememberMe().Click();
			}

			this.GetLoginBtn()?.Click();
		}


		public void ClinkOnRememberMeCheckBox()
		{
			this.GetRememberMe()?.Click();
		}


		public void ClickOnLoginBtn()
		{
			this.GetLoginBtn()?.Click();
		}

		public void ClickOnRegisterLink()
		{
			this.GetRegisterLink()?.Click();
		}

		public void ClickOnForgotPassLink()
		{
			this.GetForgotPasswordLink()?.Click();
		}

		public void ClickOnTermsLink()
		{
			this.GetTermsLink()?.Click();
		}

		public void ClickOnPrivacyLink()
		{
			this.GetPrivacyPolicyLink()?.Click();
		}

		public void ClickOnCloseBtn()
		{
			this.GetCloseBtn()?.Click();
		}

		//getters

		public IWebElement GetEmailAddress()
		{
			return this.driver.FindElement(By.XPath("//input[@name='username']"));
		}


		public IWebElement GetPassword()
		{
			return this.driver.FindElement(By.XPath("//input[@type='password']"));
		}


		public IWebElement GetRememberMe()
		{
			return this.driver.FindElement(By.XPath("//span[@class='checkbox']"));
		}

		public IWebElement GetLoginBtn()
		{
			return this.driver.FindElement(By.XPath("//button[@type='submit']"));
		}

		public IWebElement GetRegisterLink()
		{
			return this.driver.FindElement(By.XPath("//a[text()='Register']"));
		}


		public IWebElement GetForgotPasswordLink()
		{
			return this.driver.FindElement(By.XPath("//a[text()='Forgot password?']"));
		}

		public IWebElement GetTermsLink()
		{
			return this.driver.FindElement(By.XPath("//a[text()='Terms and Conditions']"));
		}


		public IWebElement GetPrivacyPolicyLink()
		{
			return this.driver.FindElement(By.XPath("//a[contains(text(),'Privacy Policy & ')]"));
		}

		public IWebElement GetCloseBtn()
		{
			return this.driver.FindElement(By.XPath("//a[@aria-label='Close modal']"));
		}


		public ReadOnlyCollection<IWebElement> GetAllAnchorElements()
		{
			ReadOnlyCollection<IWebElement> elements = this.driver.FindElements(By.XPath("//bnm-paper[@class='default']//a"));

			return elements;
		}

	}
}
