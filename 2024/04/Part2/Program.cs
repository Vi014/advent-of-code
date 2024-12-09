var lines = File.ReadAllLines("input");
var linesCnt = lines.Length;
var count = 0;

for (var i = 1; i < linesCnt - 1; i++)
{
    var line = lines[i];
    var lineCnt = line.Length;

    for (var j = 1; j < lineCnt - 1; j++)
    {
        if (lines[i][j] == 'A')
        {
            if ((lines[i-1][j-1] == 'M' && lines[i+1][j+1] == 'S') || (lines[i-1][j-1] == 'S' && lines[i+1][j+1] == 'M'))
                if ((lines[i+1][j-1] == 'M' && lines[i-1][j+1] == 'S') || (lines[i+1][j-1] == 'S' && lines[i-1][j+1] == 'M'))
                    count++;
        }
    }
}

Console.WriteLine(count);