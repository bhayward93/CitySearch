using System;
using System.Collections.Generic;

namespace CitySearch
{
    /// <summary>
    /// Holds information on the predicted next city, providing the next 
    /// possible characters and the full names of the predicted cities.
    /// </summary>
   
    public class CityResult : ICityResult
    {

        //All valid next characters for each matched city.
        public ICollection<string> NextLetters { get; set; }

        //All cities that start with the search string.
        public ICollection<string> NextCities { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CityResult() { }

        /// <summary>
        /// Constructor for a populated CityResult.
        /// </summary>
        /// <param name="nextLetters">An ICollection of type string, containing the APIs predicted next letters.</param>
        /// <param name="nextCities" >An ICollection of type string, containing the APIs predicted next city names.</param>
        public CityResult(ICollection<string> nextLetters, ICollection<string> nextCities)
        {
            this.NextCities = nextCities;
            this.NextLetters = nextLetters;
        }
 

    }
}