using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booknowmed.src.pages
{
	public abstract class BasePage
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;

		public BasePage(IWebDriver driver, WebDriverWait wait)
		{
			this.driver = driver;
			this.wait = wait;
		}
	}
}
