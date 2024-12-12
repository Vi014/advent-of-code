var lines = File.ReadAllLines("input");
var linesCnt = lines.Length;
var count = 0;

for (var i = 0; i < linesCnt; i++)
{
    var line = lines[i];
    var lineCnt = line.Length;

    for (var j = 0; j < lineCnt; j++)
    {
        if (lines[i][j] == 'X')
        {
            if (i >= 3)
            {
                if (lines[i - 1][j] == 'M' && lines[i - 2][j] == 'A' && lines[i - 3][j] == 'S') count++;
                if (j >= 3)
                    if (lines[i - 1][j - 1] == 'M' && lines[i - 2][j - 2] == 'A' && lines[i - 3][j - 3] == 'S') count++;
                if (j + 3 < lineCnt)
                    if (lines[i - 1][j + 1] == 'M' && lines[i - 2][j + 2] == 'A' && lines[i - 3][j + 3] == 'S') count++;
            }
            
            if(j >= 3)
                if(lines[i][j - 1] == 'M' && lines[i][j - 2] == 'A' && lines[i][j - 3] == 'S') count++;
            if(j + 3 < lineCnt)
                if(lines[i][j + 1] == 'M' && lines[i][j + 2] == 'A' && lines[i][j + 3] == 'S') count++;
            
            if (i + 3 < linesCnt)
            {
                if (lines[i + 1][j] == 'M' && lines[i + 2][j] == 'A' && lines[i + 3][j] == 'S') count++;
                if (j >= 3)
                    if (lines[i + 1][j - 1] == 'M' && lines[i + 2][j - 2] == 'A' && lines[i + 3][j - 3] == 'S') count++;
                if (j + 3 < lineCnt)
                    if (lines[i + 1][j + 1] == 'M' && lines[i + 2][j + 2] == 'A' && lines[i + 3][j + 3] == 'S') count++;
            }
        }
    }
}

Console.WriteLine(count);