
using System;
using System.Text.Json.Serialization;

namespace LastChristmas.Core
{
	public class Playlist
	{
		private string _name = string.Empty;

		[JsonPropertyName("name")]
		public string Name
		{
			get
			{
                return _name.Replace("Top 100:", "").
                Trim().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                FirstOrDefault("Unknown");
            }
			set
			{
				_name = value;
			}
		}
		[JsonPropertyName("track")]
		public Track[] Tracks { get; set; } = { };
	}
}

