using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    public class CityFinder : ICityFinder
    {
        private APIKey apiKey;
        private const string baseURL = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
        private string types = "&types=(cities)";

        public CityFinder(APIKey key)
        {
            this.apiKey = key;
        }
        public ICityResult Search(string searchString)
        {
            if (apiKey != null)
            {
                bool successFlag = false;
                while (successFlag == false) { //Though using a Google API, so likely very reliable, this is a safety net.
                    try
                    {
                        String url = baseURL + searchString + types + apiKey.keyString;
                        JSONGetter jsonGetter = new JSONGetter();
                        IEnumerable<CityResult> results = jsonGetter.get(url).Result;
                        successFlag = true; //If we've made it to this point, break out of the loop, else retry.
                    }
                    catch (Exception e) {
                        Debug.Write("Request unsuccessful. Printing e.Source:  \n" + e.Source);
                        Console.WriteLine(e.GetType().FullName);
                        Console.WriteLine(e.Message);
                    }

                } return null;
            } return null;
        } 
    }
}

