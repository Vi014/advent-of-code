using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input");
var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
var sum = 0;

foreach (var line in lines)
{
    var matches = regex.Matches(line);
    foreach (var match in matches)
    {
        var regex2 = new Regex(@"\d{1,3}");
        var matches2 = regex2.Matches(match.ToString()!);
        sum += Convert.ToInt32(matches2[0].Value) * Convert.ToInt32(matches2[1].Value);
    }
}

Console.WriteLine($"{sum}");