using System;
using System.Collections.Generic;

namespace CitySearch
{
    public class CityResult : ICityResult
    {
        //All valid next characters for each matched city.
        public ICollection<string> NextLetters {get; set;
        }
        //All cities that start with the search string.
        public ICollection<string> NextCities {get; set;}

    }
}