using System;
using Newtonsoft.Json;

namespace CitySearch
{
	/// <summary>
	/// The Autocomplete Prediction Substring
	/// </summary>
	public class PredictionMatchedSubstring
	{
		[JsonProperty("length")]
		public int Length { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }
	}
}

