string[] lines = File.ReadAllLines("test");

string[] numbersStr = lines[0].Split(":")[1].Trim().Split(" ");
List<long> numbers = new List<long>();

for(int i = 0; i < numbersStr.Length; i++) numbers.Add(long.Parse(numbersStr[i]));

int currLine = 3;

while(currLine < lines.Length)
{
    int lineCount = 0;

    while(currLine+lineCount < lines.Length && lines[currLine + lineCount] !=  "")
    {
        lineCount++;
    }

    string[] newMap = new string[lineCount];
    Array.Copy(lines, currLine, newMap, 0, lineCount);

    System.Console.WriteLine(currLine.ToString());
    numbers = findCorresponding(numbers, newMap);
    currLine += lineCount + 2;
}

long lowest = numbers[0];
for(int i = 1; i < numbers.Count; i++) if(numbers[i] < lowest) lowest = numbers[i];
System.Console.WriteLine($"{lowest}");


List<long> findCorresponding(List<long> inputNrs, string[] inputMap)
{
    long[,] mapL = new long[inputMap.Length, 3];
    
    for(int i = 0; i < inputMap.Length; i++)
    {
        string[] mapNrs = inputMap[i].Split(" ");

        for(int j = 0; j < 3; j++)
            mapL[i, j] = long.Parse(mapNrs[j]);
    }

    for(int i = 0; i < inputNrs.Count; i += 2)
    {
        for(int j = 0; j < mapL.GetLength(0); j++) // 0 - destination range start, 1 - source range start, 2 - range length
        {
            if(inputNrs[i] >= mapL[j, 1] && inputNrs[i] < mapL[j, 1] + mapL[j, 2])
            {
                if(inputNrs[i+1] > mapL[j, 2])
                {
                    long diff = inputNrs[i+1] - mapL[j, 2];
                    inputNrs[i+1] -= diff;
                    inputNrs.Add(inputNrs[i] + diff);
                    inputNrs.Add(diff);
                    break;
                }
            }
        }
        System.Console.WriteLine($"run {i} length {inputNrs.Count}");
    }


    for(int i = 0; i < inputNrs.Count; i += 2)
    {
        for(int j = 0; j < mapL.GetLength(0); j++) // 0 - destination range start, 1 - source range start, 2 - range length
        {
            if(inputNrs[i] >= mapL[j, 1] && inputNrs[i] < mapL[j, 1] + mapL[j, 2])
            {
                inputNrs[i] = mapL[j, 0] + (inputNrs[i] - mapL[j, 1]);
                break;
            }
        }
    }

    return inputNrs;
}

/* string[] lines = File.ReadAllLines("input");

string[] numbersStr = lines[0].Split(":")[1].Trim().Split(" ");
long[] numbersS = new long[numbersStr.Length];

for(int i = 0; i < numbersStr.Length; i++) numbersS[i] = long.Parse(numbersStr[i]);

List<long> numbersL = new List<long>();
for(int i = 1; i < numbersS.Length; i += 2)
    for(int j = 0; j < numbersS[i]; j++)
        numbersL.Add(numbersS[i-1] + j);
long[] numbers = numbersL.ToArray();

int currLine = 3;

while(currLine < lines.Length)
{
    int lineCount = 0;

    while(currLine+lineCount < lines.Length && lines[currLine + lineCount] !=  "")
    {
        lineCount++;
    }

    string[] newMap = new string[lineCount];
    Array.Copy(lines, currLine, newMap, 0, lineCount);

    numbers = findCorresponding(numbers, newMap);
    currLine += lineCount + 2;
}

long lowest = numbers[0];
for(int i = 1; i < numbers.Length; i++) if(numbers[i] < lowest) lowest = numbers[i];
System.Console.WriteLine($"{lowest}");


long[] findCorresponding(long[] inputNrs, string[] inputMap)
{
    long[,] mapL = new long[inputMap.Length, 3];
    
    for(int i = 0; i < inputMap.Length; i++)
    {
        string[] mapNrs = inputMap[i].Split(" ");

        for(int j = 0; j < 3; j++)
            mapL[i, j] = long.Parse(mapNrs[j]);
    }

    for(int i = 0; i < inputNrs.Length; i++)
    {
        for(int j = 0; j < mapL.GetLength(0); j++) // 0 - destination range start, 1 - source range start, 2 - range length
        {
            if(inputNrs[i] >= mapL[j, 1] && inputNrs[i] < mapL[j, 1] + mapL[j, 2])
            {
                inputNrs[i] = mapL[j, 0] + (inputNrs[i] - mapL[j, 1]);
                break;
            }
        }
    }

    return inputNrs;
} */