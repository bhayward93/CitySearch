using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    class JSONGetter : IGet
    {
        public Task<string> GetRequestAsync(string url) //https://maps.googleapis.com/maps/api/place/autocomplete/json?input=mid&types=(cities)&key=AIzaSyC3evyffluu_gsQxMJq0ljpCrsFdfldLoM
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(url);
            }
        }
        public async Task<IEnumerable<CityResult>> get(string url)
        {
            try
            {
                string jsonResult = await GetRequestAsync(url);
                IEnumerable<CityResult> cities = JsonConvert.DeserializeObject<IEnumerable<CityResult>>(jsonResult);
                IEnumerable<CityResult> cityResult = cities
                    .Select(p => new CityResult
                    {
                        NextCities = p.NextCities,
                        NextLetters = p.NextLetters
                    });
                return cities;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Failed to get JSON" + e.Source);
                return null;
            }


            //Need to do some error checking
        }
    }
}
    
    
