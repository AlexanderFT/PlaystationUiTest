using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace PlaystationUiTest
{   
    class NavigateToFirstItemInRightNowOnPlaystation
    {
        IWebDriver driver;
        
        
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }
        
                
        [Test]
        public void test()
        {

            // Navigate to the playstation website and maximize the window 
            driver.Url = "https://www.playstation.com/en-gb/";
            driver.Manage().Window.Maximize();

            //verify that the website is correct
            string preNavigationtitle = driver.Title;
            Assert.IsTrue(preNavigationtitle == "Official PlayStation website | PlayStation", "Title is not correct");
            driver.FindElement(By.Id("sony-bar"));
            Assert.IsTrue(driver.FindElement(By.Id("sony-bar")).Displayed);

            // Close the Cookies popup via acception 
            driver.FindElement(By.XPath("//a[@class = 'accept link-btn blue-btn']")).Click();

            // Click the Chevron to the left of Right now on playstation  
            driver.FindElement(By.XPath("//a[@class='cell double-arrow-down more-link']")).Click();

            // Verify that the tile is visible    
            IWebElement tile1 = driver.FindElement(By.XPath("//div[@class='producttile_14805072 productTile']//div[@class='btnDesktopTab']//a"));
            Assert.IsTrue(tile1.Displayed);

            // Select the first tile 
            tile1.SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(1000);

            // Verify that the page navigated to is correct
            string postNavigationtitle = driver.Title;
            Assert.IsTrue(postNavigationtitle == "Apex Legends | System Override Collection Event Trailer | PS4 - YouTube", "Title is not Correct");   
              
        }



        [TearDown]
        public void closeBrowser()
        {
           // driver.Close();
        }

      
    }
}
