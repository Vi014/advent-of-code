int sum = 0;
string[] lines = File.ReadAllLines("input");
int[] cardInstances = new int[lines.Length];

for (int i = 0; i < cardInstances.Length; i++)
{
    cardInstances[i] = 1;
}

for(int i = 0; i < lines.Length; i++)
{
    string line = lines[i];
    string[] numbers = line.Split(':')[1].Split('|');
    numbers[0] = numbers[0].Trim();
    numbers[1] = numbers[1].Trim();
    string[] winNrs = numbers[0].Split(' ');
    string[] gotNrs = numbers[1].Split(' ');

    int hits = 0;
    foreach(string winNr in winNrs)
    {
        if(winNr.Length != 0)
        {
            foreach(string gotNr in gotNrs)
            {
                if(gotNr.Length != 0)
                {
                    if(winNr == gotNr) hits++;
                }
            }
        }
    }

    for(int j = i+1; j <= i+hits; j++)
    {
        cardInstances[j] += cardInstances[i];
    }
    
    sum += cardInstances[i];
}

System.Console.WriteLine(sum.ToString());