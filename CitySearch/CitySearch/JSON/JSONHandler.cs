using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace CitySearch
{
    public class JSONHandler : IJSONHandler
    {
        private string jsonResult;

        /// <summary>
        /// Convinience method to Get, Deserialize and Parse a JSON Object.
        /// </summary>
        /// <param name="URL">The URL of the API</param>
        /// <param name="searchString">The inputted search string so far</param>
        /// <returns>A List of City objects</returns> 
        public virtual CityResult GetDeserializeParse(string searchString, string url)
        {
            try
            {
                var deserializedJSON = Deserialize(GetJSON(url));
                CityResult cityResult = ParseToCityResult(deserializedJSON, searchString);
                return cityResult;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// Returns a JSON object from a given URL.
        /// </summary>
        /// <param name="url">The completed URL of the API</param>
        /// <returns>The JSON string retrieved from the URL provided.</returns>

        public virtual string GetJSON(string url)
        {
            try{
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url); //Create a HTTPWebRequest.
                httpWebRequest.ContentType = "text/json"; //set type to JSON.
                httpWebRequest.Method = "GET"; //Allows JSON to be retrieved.
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();  //get HttpResponse
                using (var reader = new StreamReader(httpResponse.GetResponseStream())){ 
                    jsonResult = reader.ReadToEnd(); //read the response stream to construct a string
                }
                return jsonResult;
            }
            catch (Exception e)
            {
                Debug.Write("Failed to Retrieve JSON. Printing e.Source:  \n" + e.Source);     
                return null;
            }
        }


        /// <summary>
        /// Deserialize's a JSON result a Predictions object.
        /// </summary>
        /// <param name="jsonResult">The result from the API, in String form</param>
        /// <returns>The JSON string retrieved from the URL provided.</returns>

        public virtual Predictions Deserialize(string jsonResult)
        {
            try
            {
                return JsonConvert.DeserializeObject<Predictions>(jsonResult);
            }
            catch (Exception e)
            { 
                Debug.Write("Failed to deserialize JSON.", e.Source);
                return null;
            }
        }

        /// <summary>
        /// Parse a Predictions object into a CityResult object
        /// </summary>
        /// <param name="POJOs">The predictions object</param>
        /// <param name="searchString">The search string used to retrieve the JSON</param>
        /// <returns>The JSON string retrieved from the URL provided.</returns>
        public virtual CityResult ParseToCityResult(Predictions POJOs, string searchString)
        {
            try
            {
                ICollection<string> nextLetters = new List<string>();
                ICollection<string> nextCities = new List<string>();

                foreach (Prediction pred in POJOs.predictions)
                {   //Itterate through the prediction.
                    string cityName = pred.Terms[0].Value;
                    nextCities.Add(cityName);
                    nextLetters.Add(cityName[searchString.Length].ToString());
                }
                return new CityResult(nextLetters, nextCities);
            }
            catch (Exception e)
            {
                Debug.Write("Failed to parse to a CityResult object.", e.Source);
                return null;
            }
        }

  
    }
}
    
    
