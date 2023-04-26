using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverCalculatorPOM.Pages
{
    public class SumNumbersPage
    {
        private WebDriver driver;
        private const string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        public SumNumbersPage(WebDriver driver)
        {
            this.driver = driver;   
        }

        public IWebElement FirstNumber => driver.FindElement(By.Id("number1"));
        //public IWebElement firstNumber1 { get { return driver.FindElement(By.Id("number1")); } }
        public IWebElement SecondNumber => driver.FindElement(By.Id("number2"));
        public IWebElement CalcButton => driver.FindElement(By.Id("calcButton"));
        public IWebElement OperationField => driver.FindElement(By.Id("operation"));
        public IWebElement ResetButton => driver.FindElement(By.Id("resetButton"));
        public IWebElement ResultLabel => driver.FindElement(By.Id("result"));

        public void Open()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public bool IsPageOpen()
        {
            return driver.Url == baseUrl;   
        }

        public string CalcNumbers(string firstValue, string operation, string secondValue)
        {
            FirstNumber.SendKeys(firstValue);
            SecondNumber.SendKeys(secondValue);
            OperationField.SendKeys(operation);

            CalcButton.Click();

            return ResultLabel.Text;
        }
        public bool IsFormEmpty()
        {
            bool empty = (FirstNumber.Text == "" && SecondNumber.Text == ""); 
            return empty;
        }
        public void ResetForm()
        {
            ResetButton.Click();
        }


    }
}
