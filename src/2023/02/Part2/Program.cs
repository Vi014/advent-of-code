int sum = 0;
string[] lines = File.ReadAllLines("input");
for(int i = 0; i < lines.Count(); i++)
{
    string line = lines[i].Split(':')[1];
    sum += calcPow(line);
}

System.Console.WriteLine(sum.ToString());

int calcPow(string inputText)
{
    int maxR = 0, maxG = 0, maxB = 0;

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
                    if(Convert.ToInt32(counts[0].Trim()) > maxR) maxR = Convert.ToInt32(counts[0].Trim());
                    break;
                case "green":
                    if(Convert.ToInt32(counts[0].Trim()) > maxG) maxG = Convert.ToInt32(counts[0].Trim());
                    break;
                case "blue":
                    if(Convert.ToInt32(counts[0].Trim()) > maxB) maxB = Convert.ToInt32(counts[0].Trim());
                    break;
            }
        }
    }

    return maxR * maxG * maxB;
}