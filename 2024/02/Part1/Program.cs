using System.Security.AccessControl;

var lines = File.ReadAllLines("input");
var count = 0;

foreach (var line in lines)
{
    var levels = line.Split(' ');
    var safe = true;

    if (int.Parse(levels[0]) > int.Parse(levels[1]))
    {
        // all decreasing
        for (var i = 0; i < levels.Length - 1; i++)
        {
            var curr = int.Parse(levels[i]);
            var next = int.Parse(levels[i + 1]);
            if (curr - next < 1 || curr - next > 3)
            {
                safe = false;
                break;
            }
        }
    }
    else
    {
        // all increasing
        for (var i = 0; i < levels.Length - 1; i++)
        {
            var curr = int.Parse(levels[i]);
            var next = int.Parse(levels[i + 1]);
            if (next - curr < 1 || next - curr > 3)
            {
                safe = false;
                break;
            }
        }
    }

    if (safe)
    {
        count++;
    }
}

Console.WriteLine($"{count}");