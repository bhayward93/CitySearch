using System;
using System.Collections.Generic;

namespace CitySearch
{

  
    /* Holds information on the predicted next city, providing the next 
     * possible characters and the full names of the predicted cities.
     */
    public class CityResult : ICityResult
    {

        //All valid next characters for each matched city.
        public ICollection<string> NextLetters { get; set; }

        //All cities that start with the search string.
        public ICollection<string> NextCities { get; set; }

        public CityResult() { }

        public CityResult(ICollection<string> nextLetters, ICollection<string> nextCities)
        {
            this.NextCities = nextCities;
            this.NextLetters = nextLetters;
        }
 

    }
}