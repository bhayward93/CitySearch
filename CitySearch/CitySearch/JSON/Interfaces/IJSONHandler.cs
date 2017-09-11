namespace CitySearch
{
    /// <summary>
    /// The Interface specifying the layout of a JSONHandler
    /// </summary>
    internal interface IJSONHandler
    {
        string GetJSON(string url);
        Predictions Deserialize(string jsonResult);
        CityResult ParseToCityResult(Predictions POJOs, string searchString);
    }
}