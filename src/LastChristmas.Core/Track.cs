using System;
using System.Text.Json.Serialization;

namespace LastChristmas.Core
{
	public class Track
	{
		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;

		[JsonPropertyName("url")]
		public string Url { get; set; } = string.Empty;


	}
}

