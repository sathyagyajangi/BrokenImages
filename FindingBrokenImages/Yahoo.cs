using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindingBrokenImages
{
    class hreflist
    {
        public string URLs { get; set; }
    }
    class Serieslist
    {
        public string Series { get; set; }
    }
    class Yahoo
    {
        private IWebDriver driver;

        public Yahoo(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Drivercheck(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void GetUrl()
        {
            var Urllist = new List<hreflist>();

            var Serieslist = new List<Serieslist>();





            var allDivs = driver.FindElements(By.CssSelector(".si-dv-row"));

            foreach (var div in allDivs)
            {


                var url = div.GetAttribute("href");


                Urllist.Add(new hreflist { URLs = url });
                TestContext.Out.WriteLine($"URL: { url } ");



            }

            foreach (var u in Urllist)
            {
                var link = u.URLs.ToString();

                driver.Navigate().GoToUrl(link);

                var allDivs1 = driver.FindElements(By.CssSelector(".quick-links-menu"));

                foreach (var div1 in allDivs1)
                {


                    var seriesurl = div1.FindElement(By.CssSelector("a")).GetAttribute("href");


                    Serieslist.Add(new Serieslist { Series = seriesurl });
                    TestContext.Out.WriteLine($"Series: { seriesurl } ");


                }
                foreach (var s in Serieslist)
                {
                    var link1 = s.Series.ToString();

                    driver.Navigate().GoToUrl(link1);

                }
            }
        }
}   }
