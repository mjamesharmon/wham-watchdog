using System;
namespace LastChristmas.Core.Test.Shared
{
    public class RankingExtensionsCountsData :
        TheoryData<IEnumerable<Ranking>, int>
    {
        public RankingExtensionsCountsData()
        {
            Add(new List<Ranking>() {
                new Ranking("Denmark",1),
                new Ranking("Sweden",1),
                new Ranking("Austria",0),
                new Ranking("Germany",45)

            }, 2);

            Add(new List<Ranking>() {
                new Ranking("Denmark",11),
                new Ranking("Sweden",11),
                new Ranking("Austria",0),
                new Ranking("Germany",45)

            }, 0);

            Add(new List<Ranking>(), 0);
        }
    }
}


