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
                CityResult deserializedJSON = new CityResult();
                bool successFlag = false;
                while (successFlag == false) { //Though using a Google API, so likely very reliable, this is a safety net.
                    try
                    {
                        String url = baseURL + searchString + types + "&key="+apiKey.keyString;
                        JSONHandler jsonHandler = new JSONHandler();
                        deserializedJSON = jsonHandler.GetDeserializeParse(searchString, url);
                        successFlag = true; //If we've made it to this point, break out of the loop, else retry.
                        return deserializedJSON;
                    }
                    catch (Exception e) {
                        Debug.Write("Request unsuccessful. Printing e.Source:  \n" + e.Source);
                        Console.WriteLine(e.GetType().FullName);
                        Console.WriteLine(e.Message);
                    }

                } return deserializedJSON;
            } return null; //No API key.
        } 
    }
}

