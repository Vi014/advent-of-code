using System.Collections.Generic;
using System.IO;

string[] lines = File.ReadAllLines("input");
long sum = 0;

foreach(string line in lines)
{
    string[] numbersS = line.Split(" ");
    long[] numbersL = new long[numbersS.Length];
    for(int i = 0; i < numbersS.Length; i++)
        numbersL[i] = long.Parse(numbersS[i]);

    sum += predictValue(numbersL);
}

System.Console.WriteLine($"{sum}");

long predictValue(long[] inputArr)
{
    long[] nextStep = new long[inputArr.Length - 1];
    bool lastStep = true;

    for(int i = 0; i < nextStep.Length; i++)
    {
        nextStep[i] = inputArr[i+1] - inputArr[i];
        if(nextStep[i] != 0) lastStep = false;
    }

    if(!lastStep) return inputArr[0] - predictValue(nextStep);
    else return inputArr[inputArr.Length - 1];
}