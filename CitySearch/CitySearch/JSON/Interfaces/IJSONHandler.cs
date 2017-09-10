using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitySearch
{
    internal interface IJSONHandler
    {
        string GetJSON(string url);
        Predictions Deserialize(string jsonResult);
        CityResult ParseToCityResult(Predictions POJOs, string searchString);
    }
}