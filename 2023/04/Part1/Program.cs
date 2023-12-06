int sum = 0;
string[] lines = File.ReadAllLines("input");
foreach(string line in lines)
{
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
    
    if(hits != 0) sum += Convert.ToInt32(Math.Pow(2, hits - 1));
}

System.Console.WriteLine(sum.ToString());