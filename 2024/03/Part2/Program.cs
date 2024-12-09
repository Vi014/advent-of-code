using System.Text.RegularExpressions;
using System.Threading.Channels;

var lines = File.ReadAllLines("input");
var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)");
var sum = 0;
var enabled = true;

foreach (var line in lines)
{
    var matches = regex.Matches(line);
    foreach (var match in matches)
    {
        if (match.ToString() == "do()") enabled = true;
        else if (match.ToString() == "don't()") enabled = false;
        else if (enabled)
        {
            var regex2 = new Regex(@"\d{1,3}");
            var matches2 = regex2.Matches(match.ToString()!);
            sum += Convert.ToInt32(matches2[0].Value) * Convert.ToInt32(matches2[1].Value);
        }
    }
}

Console.WriteLine($"{sum}");