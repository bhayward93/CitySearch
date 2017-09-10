using CitySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            APIKey apiKey = new APIKey("AIzaSyC3evyffluu_gsQxMJq0ljpCrsFdfldLoM"); //TODO Use using here for efficiency
            CityFinder finder = new CityFinder(apiKey);
       
            Console.Write("Welcome to CitySearch's example implementation.\n" +
                          "Please enter a search string to continue:\n");
            while ("pigs" != "fly")
            {
                string searchString = Console.ReadLine();
                ICityResult results = (CityResult) finder.Search(searchString);

                Console.Write("--------------------\n" +
                              "Predicted City Names:\n\n");
                foreach (string city in results.NextCities)
                {
                    Console.Write("City Name:\t" + city + "\n");
                }

                Console.Write("--------------------\n" +
                              "Predicted Next Letters:\n\n");
                foreach (string letter in results.NextLetters)
                {
                    Console.Write("Next Letter:\t" + letter + "\n");
                }
                Console.Write("--------------------\n");
                Console.Write("Enter Another Search :\n");
            }
        }
    }
}
