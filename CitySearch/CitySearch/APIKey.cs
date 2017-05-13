using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    /**
     * Used to store the key for the API
     */
    public class APIKey : IStoredKey
    {
        public string keyString { get; set; }

        /**
         *  A free API key can be obtained at https://developers.google.com/maps/documentation/javascript/get-api-key
         *  Please enter yours as the keyString() variable.
         */
        public APIKey(string key)
        {
            this.keyString = key;
        }



    }

}
