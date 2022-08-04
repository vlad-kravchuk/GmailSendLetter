using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace sendLetter
{
    class sendLetter
    {

        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void test_search()
        {
            driver.Url = "https://accounts.ukr.net/login?lang=ru";
            //AUTHORIZATION
            var emailIdBox = driver.FindElement(By.Name("login"));
            emailIdBox.SendKeys("******"); //ukr.net email login
            var passwordBox = driver.FindElement(By.Name("password"));
            passwordBox.SendKeys("*******"); //email password
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var submitButton = driver.FindElement(By.XPath("//button[@class='Ol0-ktls jY4tHruE _2Qy_WiMj']"));
            submitButton.Click();
            //SEND LETTER
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var createLetterButton = driver.FindElement(By.XPath("//button[@class='button primary compose']"));
            createLetterButton.Click();
            var emailRecepientBox = driver.FindElement(By.Name("toFieldInput"));
            emailRecepientBox.SendKeys("*******"); //recepients email
            var iFrameBody = driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']"));
            iFrameBody.Click();
            iFrameBody.SendKeys("hello friend");
            var sendLetterButton = driver.FindElement(By.XPath("//button[@class='button primary send']"));
            sendLetterButton.Click();
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}