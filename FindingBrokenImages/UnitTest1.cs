using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FindingBrokenImages
{

    class ImagesList
    {
        public string IMAGE { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {

       
        [TestMethod]
        public void TestMethod1()
        {


            
            IWebDriver driver = new ChromeDriver();

            for (int k =2; k <= 12; k++)

            {
                string url=FunctionLibrary.ReadDataExcel(1, k, 1);




                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                var Imageslist = new List<ImagesList>();

                int count = (int)(driver.FindElements(By.TagName("img"))).Count;

                Console.WriteLine(count);
                var allImages = driver.FindElements(By.TagName("img"));
                foreach (var img in allImages)
                {
                    var imgSrc = img.GetAttribute("src");
                    Imageslist.Add(new ImagesList { IMAGE = imgSrc });
                    NUnit.Framework.TestContext.Out.WriteLine($"IMAGE:{imgSrc}");
                }



                foreach (var i in Imageslist)
                {
                    string link = i.IMAGE.ToString();



                    if (link == "")

                    {
                        Console.WriteLine("src empty");

                    }
                    else
                    {
                        string brokenlink = link.Substring(8, 2);



                        if (brokenlink.Equals("s3"))
                        {


                            Console.WriteLine(link.Substring(72));
                        }
                    }

                }


            }
        }

        [TestMethod]

        public void temp()
        {
            string str = "https://s3.ap-south-1.amazonaws.com/assets-cricket.yahoo.sportz.io/prod/waf-images/13/56/d9/16-9/388-218/1f0b9b19da418f1c4fb9e90ed19e23d6.jpeg";
                                                                                                                    
           string str1= str.Substring(105);

            Console.WriteLine(str1);
        }



        [TestMethod]

        public void atk()

        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.indiansuperleague.com/");
            driver.Manage().Window.Maximize();

            var Imageslist = new List<ImagesList>();

            int count = (int)(driver.FindElements(By.TagName("span"))).Count;

            Console.WriteLine(count);
            var allImages = driver.FindElements(By.TagName("span"));
            foreach (var img in allImages)
            {
                var imgSrc = img.Text;
                Imageslist.Add(new ImagesList { IMAGE = imgSrc });
                NUnit.Framework.TestContext.Out.WriteLine($"IMAGE:{imgSrc}");
            }


            foreach (var i in Imageslist)
            {

                string link = i.IMAGE.ToString();

                Console.WriteLine(link);
                if (i.Equals("ATK"))
                {

                    Console.WriteLine("ATK");
                }
          

            }

        }

    }
}
