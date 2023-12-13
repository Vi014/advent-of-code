using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;

string[] lines = File.ReadAllLines("input");

string[] hands = new string[lines.Length];
int[] bids = new int[lines.Length];

for(int i = 0; i < lines.Length; i++)
{
    string[] values = lines[i].Split(" ");
    hands[i] = values[0];
    bids[i]  = int.Parse(values[1]);
}

bool done;
for(int i = 0; i < lines.Length - 1; i++)
{
    done = true;
    for(int j = 0; j < lines.Length - i - 1; j++)
    {
        if(cmpHand(hands[j], hands[j+1]))
        {
            string tmpS = hands[j];
            int tmpI    = bids[j];

            hands[j] = hands[j+1];
            bids[j]  = bids[j+1];
            hands[j+1] = tmpS;
            bids[j+1]  = tmpI;

            done = false;
        }
    }
    if(done) break;
}

int sum = 0;
for(int i = 0; i < lines.Length; i++)
    sum += bids[i] * (i+1);
System.Console.WriteLine($"{sum}");

bool cmpHand(string left, string right) // returns true if left > right, false otherwise
{
    char[] leftA = left.ToArray(), rightA = right.ToArray();
    Array.Sort(leftA);
    Array.Sort(rightA);

    if(handType(leftA) > handType(rightA))
        return true;
    else if(handType(leftA) < handType(rightA))
        return false;
    else
        for(int i = 0; i < 5; i++)
        {
            if(cardValue(left[i]) > cardValue(right[i])) 
                return true;
            else if(cardValue(left[i]) < cardValue(right[i]))
                return false;
        }

    return false;
}

int handType(char[] input)
{
    HashSet<char> inSet = input.ToHashSet();
    int jokerCount = elCount(input, 'J');

    switch(inSet.Count)
    {
        case 1:
            return 6;
        case 2:
            if(jokerCount > 0) return 6;
            foreach(char card in inSet)
                if(elCount(input, card) == 4)
                    return 5;
            return 4;
        case 3:
            if(jokerCount >= 2) return 5;
            foreach(char card in inSet)
                if(elCount(input, card) == 3)
                    if(jokerCount == 1) return 5;
                    else return 3;
            if(jokerCount == 1) return 4;
            return 2;
        case 4:
            if(jokerCount > 0) return 3;
            return 1;
        case 5:
            if(jokerCount == 1) return 1;
            return 0;
        default:
            return 0;
    }
}

int cardValue(char input)
{
    switch(input)
    {
        case 'T':
            return 10;
        case 'J':
            return 1;
        case 'Q':
            return 12;
        case 'K':
            return 13;
        case 'A':
            return 14;
        default:
            return input - '0';
    }
}

int elCount(char[] inArray, char inElement) 
{
    int count = 0;
    foreach(var element in inArray)
        if(element == inElement)
            count++;
    return count;
}