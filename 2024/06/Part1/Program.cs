using System.Text;

var map0 = File.ReadAllLines("input");
var map = map0.Select(line => new StringBuilder(line)).ToList();
int guardX = -1, guardY = -1, dir = 0;

for (var i = 0; guardX == -1; i++)
{
    for (var j = 0; j < map[i].Length; j++)
    {
        if (map[i][j] == '^')
        {
            guardX = i;
            guardY = j;
            break;
        }
    }
}

int nextX = guardX, nextY = guardY;

while (nextX >= 0 && nextX < map[0].Length && nextY >= 0 && nextY < map.Count)
{
    map[guardX][guardY] = 'X';
    
    if (map[nextX][nextY] == '#')
    {
        dir++;
        dir %= 4;
    }
    else
    {
        guardX = nextX;
        guardY = nextY;
    }
    
    switch (dir)
    {
        case 0:
            nextX = guardX - 1;
            nextY = guardY;
            break;
        case 1:
            nextX = guardX;
            nextY = guardY + 1;
            break;
        case 2:
            nextX = guardX + 1;
            nextY = guardY;
            break;
        case 3:
            nextX = guardX;
            nextY = guardY - 1;
            break;
        default:
            break;
    }
}
map[guardX][guardY] = 'X';

var count = 0;
for (var i = 0; i < map.Count; i++)
    for (var j = 0; j < map[i].Length; j++)
        if (map[i][j] == 'X')
            count++;
Console.WriteLine(count);