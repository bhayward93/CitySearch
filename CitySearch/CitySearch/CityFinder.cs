using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    class CityFinder : APIKey
    {
        private APIKey apiKey = new APIKey();
        private const string baseURL = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
        private string types = "&types=(cities)";
        public ICityResult Search(string searchString)
        {
            bool successFlag = false; 
            while (successFlag == false){ //Though using a Google API, so likely very reliable, this is a safety net.
                try
                {
                    IStoredKey apiKey = new APIKey("AIzaSyC3evyffluu_gsQxMJq0ljpCrsFdfldLoM");
                    String url = baseURL  + searchString + types + apiKey; return null;
                    successFlag = true; //If we've made it to this point, break out of the loop, else retry.
                }
                catch (Exception e) {
                    Debug.Write("Request unsuccessful. Printing e.Source:  \n" + e.Source);
                }
                return null;
            }
            }
    }
}
