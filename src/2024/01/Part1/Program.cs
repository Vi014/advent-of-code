using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input");
var regex = new Regex(@"\d+");
var left  = new List<int>();
var right = new List<int>();

foreach (var line in lines)
{
    var matches = regex.Matches(line);
    left.Add(Convert.ToInt32(matches[0].Value));
    right.Add(Convert.ToInt32(matches[1].Value));
}

left.Sort();
right.Sort();
var sum = 0;

for (var i = 0; i < left.Count; i++)
{
    sum += Math.Abs(left.ElementAt(i) - right.ElementAt(i));
}

Console.WriteLine($"{sum}");