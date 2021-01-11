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
	public class MessagesPage : BasePage
	{
		public MessagesPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
		{
		}

		public bool IsTitleDisplayed()
		{
			ReadOnlyCollection<IWebElement> lista = null;

			lista = this.driver.FindElements(By.XPath("//h1[text()='Login']"));

			return lista.Count() > 0 ? true : false;
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


		public IWebElement GetH1()
		{
			return this.driver.FindElement(By.XPath("/html/body/app-root/ng-component/bnm-layout/div[2]/main/div[1]/h1"));

		}


		public bool GetSuccessMessage()
		{
			return this.wait.Until(ExpectedConditions.TextToBePresentInElement(element: this.GetH1(), text: "Our suggestions (Dialysis HD clinics)"));

		}
	}
}
