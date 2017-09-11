using Newtonsoft.Json;

namespace CitySearch
{
    /// <summary>
    /// PredictionMatchedSubstring POJO.
    /// </summary>
    public class PredictionMatchedSubstring
	{
		[JsonProperty("length")]
		public int Length { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }
	}
}

