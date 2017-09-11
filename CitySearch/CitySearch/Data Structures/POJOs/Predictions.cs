using System.Collections.Generic;
using Newtonsoft.Json;

namespace CitySearch
{
	/// <summary>
	/// Predictions POJO, which holds an IEnumerable of multiple Prediction objects.
	/// </summary>
	public class Predictions
	{
		[JsonProperty("status")]
		public string status { get; set; }

		[JsonProperty("predictions")]
		public IEnumerable<Prediction> predictions { get; set; }
	}
}

