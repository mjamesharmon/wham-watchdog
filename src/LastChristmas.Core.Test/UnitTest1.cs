namespace LastChristmas.Core.Test;

using LastChristmas.Core.Extensions;

public class UnitTest1
{
    [Fact]
    public async void Test1()
    {
        HttpClient client = new HttpClient();
        var rankings = await client.GetLastChristmasRankingsAsync();


       
    }
}