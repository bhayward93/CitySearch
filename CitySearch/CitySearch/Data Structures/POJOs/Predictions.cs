using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CitySearch
{
	/// <summary>
	/// The Autocomplete Prediction Collection
	/// </summary>
	public class Predictions
	{
		[JsonProperty("status")]
		public string status { get; set; }

		[JsonProperty("predictions")]
		public IEnumerable<Prediction> predictions { get; set; }
	}
}

