namespace CitySearch
{
    /// <summary>
    /// Interface for a CityFinder.
    /// </summary>
    public interface ICityFinder
    {
        /// <summary>
        /// Searches the Google Autocomplete Places API for predicted next cities and letters.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>ICityResult that contains the next letters and cities. </returns>
        ICityResult Search(string searchString);
    }
}
