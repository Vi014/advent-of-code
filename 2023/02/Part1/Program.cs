int sum = 0;
string[] lines = File.ReadAllLines("input");
for(int i = 0; i < lines.Count(); i++)
{
    string line = lines[i].Split(':')[1];
    if(check(line)) sum += i + 1;
}

System.Console.WriteLine(sum.ToString());

bool check(string inputText)
{
    string[] draws = inputText.Split(';');

    foreach(string draw in draws)
    {
        string[] colors = draw.Split(',');

        foreach(string color in colors)
        {
            string[] counts = color.Trim().Split(' ');

            switch(counts[1])
            {
                case "red":
                    if(Convert.ToInt32(counts[0].Trim()) > 12) return false;
                    break;
                case "green":
                    if(Convert.ToInt32(counts[0].Trim()) > 13) return false;
                    break;
                case "blue":
                    if(Convert.ToInt32(counts[0].Trim()) > 14) return false;
                    break;
            }
        }
    }

    return true;
}