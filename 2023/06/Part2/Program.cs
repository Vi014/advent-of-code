using System.Globalization;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input");
long time = 0, distance = 0;

for(int i = 0; i < lines.Length; i++)
{
    string[] numbers = Regex.Split(lines[i], @"\s+");
    string number = "";
    for(int j = 1; j < numbers.Length; j++) number += numbers[j];
    if(i == 0) time = long.Parse(number);
    else distance = long.Parse(number);
}

long min = 0, max = 0; 

for(long i = 1; min == 0; i++)
    if(i * (time - i) > distance) min = i;

for(long i = time - 1; max == 0; i--)
    if(i * (time - i) > distance) max = i;

System.Console.WriteLine($"{max-min+1}");