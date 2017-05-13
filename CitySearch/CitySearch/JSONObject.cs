using System.Net;

namespace CitySearch
{
    internal class JSONObject
    {
        private HttpWebResponse httpResponse;

        public JSONObject(HttpWebResponse httpResponse)
        {
            this.httpResponse = httpResponse;
        }
    }
}