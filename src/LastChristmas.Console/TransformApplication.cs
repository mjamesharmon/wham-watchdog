using System;
using LastChristmas.Core;
using LastChristmas.Core.Extensions;

namespace LastChristmas.Transform
{
    public class TransformerApplication
    {
        private HttpClient _http = new HttpClient();

        private List<Func<LastChristmasRankingResponse, Task>> _actions =
            new List<Func<LastChristmasRankingResponse, Task>>();

        public static TransformerApplication Misconfigured =>
            new TransformerApplication();

        public async Task RunAsync() {

            if (ShouldExecute == false)
                return;
            
            var response = await _http.GetLastChristmasRankingsAsync();
            await ExecuteAll(response);
        }

        internal void AddAction(Func<LastChristmasRankingResponse,Task>
            action)
        {
            _actions.Add(action);
        }

  
        private async Task ExecuteAll(LastChristmasRankingResponse response) {
           
            await Task.WhenAll(
                _actions.Select(action => action(response))
                .ToArray());
        } 

        private bool ShouldExecute =>
            _actions.Count() > 0;
    }
}

