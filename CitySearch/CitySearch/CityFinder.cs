using System;
using System.Diagnostics;


namespace CitySearch
{   
    /// <summary>
    /// The core of CitySearch library, making the top level calls. 
    /// Enforces the instatiation of an APIKey object.
    /// </summary>
    public class CityFinder : ICityFinder
    {
        private APIKey apiKey; 
        private const string baseURL = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input="; 
        private string types = "&types=(cities)";

        /// <summary>
        /// Constructor for a CityFinder object.
        /// </summary>
        /// <param name="key">An APIKey object, holding the value of an APIKey for Google Cities AutoComplete</param>
        public CityFinder(APIKey key)
        {
            this.apiKey = key; 
        }

        /// <summary>
        /// Queries the API, given a search-string, returning a CityResult object.  
        /// </summary>
        /// <param name="searchString">The partially completed string to be search</param>
        /// <returns>CityResult object, containing the next letters, and next city names as lists of strings</returns>
        public ICityResult Search(string searchString)
        {
                CityResult deserializedJSON = new CityResult();
                while (1 == 1) { 
                    try
                    {
                        string url = baseURL + searchString + types + "&key="+apiKey.keyString;
                        JSONHandler jsonHandler = new JSONHandler();
                        deserializedJSON = jsonHandler.GetDeserializeParse(searchString, url);
                        return deserializedJSON;
                    }
                    catch (Exception e) {
                        Debug.Write("Request unsuccessful. Retrying & Printing e.Source:  \n" + e.Source);
                        Console.WriteLine(e.GetType().FullName, "\n", e.Message);
                    }
                } 
            return null; 
        } 
    }
}

