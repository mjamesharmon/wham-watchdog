using System;
using LastChristmas.Core.Test.Extensions;
using LastChristmas.Core.Test.Shared;
using LastChristmas.Core.Extensions;

namespace LastChristmas.Core.Test
{
	public class HttpClientExtensionsTests
	{

		private HttpClient? _http;

		private HttpClient Http => _http ??
			throw new NullReferenceException();


		[Theory]
		[ClassData(typeof(SimpleTheoryDataSet))]
		public async void GetRankings_SimpleRequest_ResponseOk(
			string payload, IEnumerable<Ranking> expectedRankings) {

			Arrange(payload);

			var results = await Http.GetLastChristmasRankingsAsync();

			Assert.NotNull(results);
			Assert.Equal(expectedRankings, results.Rankings);

		}


		private void Arrange(string? expectedPayload = default) {

			_http = new HttpClient(new MockHttpMessageHandler().
				WithDefaults(expectedPayload));

			
		}


	}
}

