using System;
using System.IO;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input");

string directions = lines[0];
string[] nodes = new string[lines.Length - 2], nodesL = new string[lines.Length - 2], nodesR = new string[lines.Length - 2];

for(int i = 2; i < lines.Length; i++)
{
    MatchCollection matches = Regex.Matches(lines[i], @"[A-Z]+");
    nodes[i-2]  = matches[0].Value;
    nodesL[i-2] = matches[1].Value;
    nodesR[i-2] = matches[2].Value;
}

string currNode = "AAA";
int currIndex = Array.IndexOf(nodes, currNode), stepsTaken = 0, stepIndex = 0;

while(currNode != "ZZZ")
{
    if(stepIndex == directions.Length) stepIndex = 0;

    if(directions[stepIndex] == 'L')
        currNode = nodesL[currIndex];
    else
        currNode = nodesR[currIndex];

    currIndex = Array.IndexOf(nodes, currNode);
    stepsTaken++;
    stepIndex++;
}

System.Console.WriteLine($"{stepsTaken}");