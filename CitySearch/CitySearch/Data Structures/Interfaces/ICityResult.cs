namespace CitySearch
{
    using System.Collections.Generic;

    /// <summary>
    /// The object used to hold the next letters, and next cities predicted.
    /// </summary>
    public interface ICityResult
    {
        ICollection<string> NextLetters { get; set; }
        ICollection<string> NextCities { get; set; }
    }
}
