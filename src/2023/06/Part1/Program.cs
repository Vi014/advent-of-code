using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input");
int[,] values = new int[lines.Length, (Regex.Split(lines[0], @"\s+").Length)-1];

for(int i = 0; i < lines.Length; i++)
{
    string[] numbers = Regex.Split(lines[i], @"\s+");
    for(int j = 1; j < numbers.Length; j++) values[i, j-1] = int.Parse(numbers[j]);
}

int product = 1;
for(int i = 0; i < values.GetLength(1); i++)
{
    int wayCnt = 0;

    for(int j = 1; j < values[0, i]; j++) 
    {
        if(j * (values[0, i]-j) > values[1, i]) wayCnt++;
    }

    product *= wayCnt;
}

System.Console.WriteLine($"{product}");