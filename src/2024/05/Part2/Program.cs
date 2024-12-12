var lines = File.ReadAllLines("input");
var splitIndex = Array.IndexOf(lines, "");

var rulesStrings = lines.Take(splitIndex).ToArray();
var printStrings = lines.Skip(splitIndex+1).ToArray();

var rulesInts = new List<int[]>();
var printInts = new List<int[]>();



foreach (var ruleString in rulesStrings)
{
    var ruleNrs = ruleString.Split('|');
    var newRule = new int[] { int.Parse(ruleNrs[0]), int.Parse(ruleNrs[1]) };
    rulesInts.Add(newRule);
}

foreach (var printString in printStrings)
{
    var printNrs = printString.Split(',');
    var newPrint = new List<int>();
    
    foreach(var printNr in printNrs) 
        newPrint.Add(int.Parse(printNr));
    
    printInts.Add(newPrint.ToArray());
}



var sum = 0;

foreach (var update in printInts)
{
    int shufflesDone = CheckUpdate(update, 0);

    if (shufflesDone != 0)
    {
        sum += update[update.Length / 2];
    }
}

Console.WriteLine(sum);
return;



int CheckUpdate(int[] update, int previousShuffles)
{
    for (var i = 1; i < update.Length; i++)
    {
        foreach (var rule in rulesInts)
        {
            if (rule[0] == update[i])
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    if (update[j] == rule[1])
                    {
                        (update[j], update[i]) = (update[i], update[j]);
                        return CheckUpdate(update, previousShuffles+1);
                    }
                }
            }
        }
    }
    
    return previousShuffles;
}