﻿using LastChristmas.Core;
using LastChristmas.Core.Extensions;
using LastChristmas.Console;

HttpClient http = new HttpClient();
string response = await http.GetLastChristmasRankingsAsync().
    ContinueWith(t => t.Result.Display());

Console.Out.WriteLine(response);
