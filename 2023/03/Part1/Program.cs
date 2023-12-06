int sum = 0;
string[] lines = File.ReadAllLines("input");
for(int i = 0; i < lines.Count(); i++)
{
    string line = lines[i];
    for(int j = 0; j < line.Count(); j++)
    {
        if(char.IsNumber(line[j]))
        {
            int numLength;
            for(numLength = 1; j+numLength < line.Count() && char.IsNumber(line[j+numLength]); numLength++);

            bool isPartNumber = false;
            for(int k = 0; k < numLength; k++)
            {
                for(int l = -1; l <= 1; l++)
                {
                    for(int m = -1; m <= 1; m++)
                    {
                        try
                        {
                            if(!char.IsNumber(lines[i + l][j + k + m]) && lines[i + l][j + k + m] != '.')
                            {
                                isPartNumber = true;
                                break;
                            }
                        }
                        catch {}
                    }
                }
            }

            if(isPartNumber) sum += Convert.ToInt32(line.Substring(j, numLength));
            j += numLength - 1;
        }
    }
}
System.Console.WriteLine(sum.ToString());
