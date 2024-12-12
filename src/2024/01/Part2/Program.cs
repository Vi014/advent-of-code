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

var sum = 0;

for (var i = 0; i < left.Count; i++)
{
    var similarity = 0;
    for (var j = 0; j < right.Count; j++)
    {
        if (left[i] == right[j])
        {
            similarity++;
        }
    }
    sum += left[i] * similarity;
}

Console.WriteLine($"{sum}");