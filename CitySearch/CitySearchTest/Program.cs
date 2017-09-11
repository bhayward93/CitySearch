using CitySearch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                APIKey apiKey = new APIKey("AIzaSyC3evyffluu_gsQxMJq0ljpCrsFdfldLoM");  //Provide an APIKey for the API
                CityFinder finder = new CityFinder(apiKey); //Instantiate a new CityFinder

                Console.Write("Welcome to CitySearch's example implementation.\n" +
                              "Please enter a search string to continue:\n");

                while ("pigs" != "fly")
                {
                    string searchString = Console.ReadLine(); //Await user input.
                    ICityResult results = (CityResult)finder.Search(searchString); //Search the API using the finder, and a search string parameter

                    Console.Write("--------------------\n" +
                                  "Predicted City Names:\n\n");

                    foreach (string city in results.NextCities)
                    {   //Itterate through the cities in the results and write them to console
                        Console.Write("City Name:\t" + city + "\n");
                    }

                    Console.Write("--------------------\n" +
                                  "Predicted Next Letters:\n\n");
                    foreach (string letter in results.NextLetters)
                    {   //Same as as above, but for the next letters.
                        Console.Write("Next Letter:\t" + letter + "\n");
                    }
                    Console.Write("--------------------\n");
                    Console.Write("Enter Another Search :\n");
                }
            }
            catch (Exception e)
            {
                Debug.Write("Program quit unexpectedly: \n", e.Source);
            }
            }
        }
    }

