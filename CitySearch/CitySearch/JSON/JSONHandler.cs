using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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

         public CityResult GetDeserializeParse(string searchString, string url) //url construction should happen in here.
        {
            var deserializedJSON = Deserialize(GetJSON(url));
            CityResult cityResult = ParseToCityResult(deserializedJSON, searchString);    
            return cityResult; //TODO: Set this.
        }


        /// <summary>
        /// Returns a JSON object from a given URL.
        /// </summary>
        /// <param name="url">The URL of the API</param>
        /// <returns>The JSON string retrieved from the URL provided.</returns>
     
        public string GetJSON(string url)
        {
            try{
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "text/json"; //new JSON request
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse(); //new HttpWebResponse
                using (var reader = new StreamReader(httpResponse.GetResponseStream())){
                    jsonResult = reader.ReadToEnd();
                }
                return jsonResult;
            }
            catch (Exception e)
            {
                Debug.Write("Failed to Retrieve JSON. Printing e.Source:  \n" + e.Source);
                Thread.Sleep(5000); //wait and make another request.
                GetJSON(url);
                return null;
            }
        }


        /// <summary>
        /// Deserialize's a JSON result into Prediction objects.
        /// </summary>
        /// <param name="jsonResult">the result from the API, in String form</param>
        /// <returns>The JSON string retrieved from the URL provided.</returns>

        public Predictions Deserialize(string jsonResult)
        {
            return JsonConvert.DeserializeObject<Predictions>(jsonResult);
        }

        /// <summary>
        /// Parse a Predictions object into a CityResult object
        /// </summary>
        /// <param name="POJOs">The predictions object</param>
        /// <param name="searchString">The search string used to retrieve the JSON</param>
        /// <returns>The JSON string retrieved from the URL provided.</returns>

        public CityResult ParseToCityResult(Predictions POJOs, string searchString)
        {
            ICollection<string> nextLetters = new List<string>();
            ICollection<string> nextCities = new List<string>();

            foreach (Prediction pred in POJOs.predictions) { //Itterate through the prediction.
                string cityName = pred.Terms[0].Value;
                nextCities.Add(cityName);
                nextLetters.Add(cityName[searchString.Length].ToString());
            }
            return new CityResult(nextLetters, nextCities);
        }

  
    }
}
    
    
