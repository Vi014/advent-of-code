using System.Text;

var mapInit = File.ReadAllLines("input").Select(line => new StringBuilder(line)).ToList();
var map = mapInit.Select(line => new StringBuilder(line.ToString())).ToList();
int initX = -1, initY = -1, dir = 0;

for (var i = 0; initX == -1; i++)
{
    for (var j = 0; j < map[i].Length; j++)
    {
        if (map[i][j] == '^')
        {
            initX = i;
            initY = j;
            break;
        }
    }
}

int guardX = initX, guardY = initY, nextX = initX, nextY = initY;

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
map[initX][initY] = '^';

var count = 0;
for (var i = 0; i < map.Count; i++)
    for (var j = 0; j < map[i].Length; j++)
        if (map[i][j] == 'X')
            count += TestPlacement(i, j);
Console.WriteLine(count);
return;



int TestPlacement(int obsX, int obsY)
{
    var mapTest = mapInit.Select(line => new StringBuilder(line.ToString())).ToList();
    mapTest[obsX][obsY] = '#';

    guardX = initX;
    guardY = initY;
    nextX = initX;
    nextY = initY;
    dir = 0;
    
    var loopCnt = 0;
    
    while (nextX >= 0 && nextX < mapTest[0].Length && nextY >= 0 && nextY < mapTest.Count)
    {
        if (loopCnt == 9999) return 1; // this is how engineers do things, right?
        
        if (mapTest[nextX][nextY] == '#')
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

        loopCnt++;
    }

    return 0;
}