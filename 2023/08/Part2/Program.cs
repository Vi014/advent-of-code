using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input");

string directions = lines[0];
string[] nodes = new string[lines.Length - 2], nodesL = new string[lines.Length - 2], nodesR = new string[lines.Length - 2];

for(int i = 2; i < lines.Length; i++)
{
    MatchCollection matches = Regex.Matches(lines[i], @"[A-Z0-9]+");
    nodes[i-2]  = matches[0].Value;
    nodesL[i-2] = matches[1].Value;
    nodesR[i-2] = matches[2].Value;
}

List<string> currNodesL = new List<string>();
List<int> currIndexesL = new List<int>();
for(int i = 0; i < nodes.Length; i++)
{   
    if(nodes[i][2] == 'A') 
    {   
        currNodesL.Add(nodes[i]);
        currIndexesL.Add(i);
    }
}

string[] currNodes = currNodesL.ToArray();
int[] currIndexes = currIndexesL.ToArray();
long[] stepsNeeded = new long[currNodes.Length];
int stepsTaken = 0, stepIndex = 0;

for(int i = 0; i < currNodes.Length; i++)
{
    while(currNodes[i][2] != 'Z')
    {
        if(stepIndex == directions.Length) stepIndex = 0;

        if(directions[stepIndex] == 'L')
            currNodes[i] = nodesL[currIndexes[i]];
        else
            currNodes[i] = nodesR[currIndexes[i]];

        currIndexes[i] = Array.IndexOf(nodes, currNodes[i]);
        stepsTaken++;
        stepIndex++;
    }

    stepsNeeded[i] = stepsTaken;
    stepsTaken = 0;
}

long answer = lcm(stepsNeeded[0], stepsNeeded[1]);
for(int i = 2; i < stepsNeeded.Length; i++)
    answer = lcm(answer, stepsNeeded[i]);
System.Console.WriteLine($"{answer}");


long gcd(long a, long b)
{
    long r = a % b;
    if(r == 0) return b;
    else return gcd(b, r);
}

long lcm(long a, long b)
{
    return Math.Abs(a * b) / gcd(a,b);
}