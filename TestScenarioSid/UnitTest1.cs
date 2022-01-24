using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestScenarioSid
{
    public class Tests
    {
        //Change the User details if needed 

        readonly string togo_url = "https://demo.openmrs.org/openmrs/";
        readonly string Username = "Admin";
        readonly string Password = "Admin123";

        readonly string Givenname = "Jim";
        readonly string Familyname = "Bert";
        readonly string Birthdate = "23";
        readonly string Birthmonth = "April";
        readonly string Birthyear = "1980";

        readonly string Adrs1 = "No 10";
        readonly string Adrs2 = "main block";
        readonly string city = "London";
        readonly string country = "UK";
        readonly string state = "state";
        readonly string postal = "542187";



        public IWebDriver driver;

        

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            try
            {
                //navigate to the URL
                driver.Navigate().GoToUrl(togo_url);

                //Entering Credentials
                driver.FindElement(By.Id("username")).SendKeys(Username);
                driver.FindElement(By.Id("password")).SendKeys(Password);
                driver.FindElement(By.Id("Inpatient Ward")).Click();
                driver.FindElement(By.Id("loginButton")).Click();
                

                //Finding & clicking Regd. Patients
                driver.FindElement(By.Id("referenceapplication-registrationapp-registerPatient-homepageLink-referenceapplication-registrationapp-registerPatient-homepageLink-extension")).Click();


                //Entering Patient Details
                driver.FindElement(By.Name("givenName")).SendKeys(Givenname);
                driver.FindElement(By.Name("familyName")).SendKeys(Familyname);
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();
                
                //Selecting Gender
                driver.FindElement(By.XPath("//option[@value='M']")).Click();
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                //Filling DOB
                driver.FindElement(By.Id("birthdateDay-field")).SendKeys(Birthdate);
                new SelectElement(driver.FindElement(By.Id("birthdateMonth-field"))).SelectByText(Birthmonth);
                driver.FindElement(By.Id("birthdateYear-field")).SendKeys(Birthyear);
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                //Filling Adresses
                driver.FindElement(By.Id("address1")).SendKeys(Adrs1);
                driver.FindElement(By.Id("address2")).SendKeys(Adrs2);
                driver.FindElement(By.Id("cityVillage")).SendKeys(city);
                driver.FindElement(By.Id("stateProvince")).SendKeys(state);
                driver.FindElement(By.Id("country")).SendKeys(country);
                driver.FindElement(By.Id("postalCode")).SendKeys(postal);
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                //Submitting Entered Dertails
                driver.FindElement(By.Id("submit")).Click();


                //Starting a Visit 
                driver.FindElement(By.LinkText("Start Visit")).Click();
                driver.FindElement(By.Id("start-visit-with-visittype-confirm")).Click();

                //Capturing Vital Details
                driver.FindElement(By.Id("referenceapplication.realTime.vitals")).Click();

                //Entering all Health Data
                driver.FindElement(By.Id("w8")).SendKeys("188");
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                driver.FindElement(By.Id("w10")).SendKeys("88");
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                driver.FindElement(By.Id("w12")).SendKeys("32");
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                driver.FindElement(By.Id("w14")).SendKeys("78");
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                driver.FindElement(By.Id("w16")).SendKeys("78");
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();


                driver.FindElement(By.Id("w18")).SendKeys("120");
                driver.FindElement(By.Id("w20")).SendKeys("90");
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                driver.FindElement(By.Id("w22")).SendKeys("99");
                driver.FindElement(By.XPath("//button[@id='next-button']/icon")).Click();

                //Submitting all Health Data
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();

                //Viewing the Data Entered
                driver.FindElement(By.ClassName("show-details")).Click();

                //Holding the page for 20 Secs before LOG-OUT
                Thread.Sleep(20000);

                //Logging-Out 
                driver.FindElement(By.LinkText("Logout")).Click();

                //After Logged-Out Driver will wait for 5Secs, then Quit


                //Assert.Pass();
            }
            catch (Exception ex)
            {
                Console.WriteLine("General exception. {0}", ex.Message);
            }
            finally { }
        }

        [TearDown]
        public void Quit_browser()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }

    
}