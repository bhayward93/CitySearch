using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch.Tests
{
    [TestClass()]
    public class CityFinderTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            APIKey apiKey = new APIKey("AIzaSyC3evyffluu_gsQxMJq0ljpCrsFdfldLoM"); //TODO Use using here for efficiency
            CityFinder finder = new CityFinder(apiKey);
            ICityResult results = (CityResult)finder.Search("mid");

            ICollection<string> nextLetters = new List<string>();
            ICollection<string> nextCities  = new List<string>();

            nextCities.Add("Midland");
            nextCities.Add("Midrand");
            nextCities.Add("Midlothian");
            nextCities.Add("Middlesbrough");
            nextCities.Add("Middletown");

            nextLetters.Add("l");
            nextLetters.Add("r");
            nextLetters.Add("l");
            nextLetters.Add("d");
            nextLetters.Add("d");

            ICityResult testResults = new CityResult(nextLetters, nextCities);

            for (int i = 0; i > nextCities.Count; i++)
            {
                Assert.AreEqual(testResults.NextCities.ElementAt(i), results.NextCities.ElementAt(i));
            }

            for (int i = 0; i > nextLetters.Count; i++)
            {
                Assert.AreEqual(testResults.NextLetters.ElementAt(i), results.NextLetters.ElementAt(i));
            }
        }
    }
}