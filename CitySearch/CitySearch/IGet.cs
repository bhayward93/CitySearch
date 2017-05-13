using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitySearch
{
    internal interface IGet
    {
        Task<IEnumerable<CityResult>> get(string url);
    }
}