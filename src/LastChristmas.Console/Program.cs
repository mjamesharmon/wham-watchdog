using LastChristmas.Core;
using LastChristmas.Core.Extensions;

HttpClient http = new HttpClient();
string response = await http.GetLastChristmasRankingsAsync().
    ContinueWith(t => t.Result.Rankings.Transform());

Console.Out.WriteLine(response);
