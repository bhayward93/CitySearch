using System;
using Newtonsoft.Json;

namespace CitySearch
{
	/// <summary>
	/// POJO representing the PredictionTerm field of the JSON.
	/// </summary>
	public class PredictionTerm
	{
		[JsonProperty("offset")]
		public int Offset { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}
}