int sum = 0;
string[] lines = File.ReadAllLines("input");
for(int i = 1; i < lines.Count() - 1; i++)
{
    string line = lines[i];
    for(int j = 1; j < line.Count() - 1; j++)
    {
        if(line[j] == '*')
        {
            int nrCount = 0;
            int gearRatio = 1;

            if(char.IsNumber(lines[i-1][j]))
            {
                nrCount++;
                string currLine = lines[i-1];

                int lengthL, lengthR;
                for(lengthL = 0; j-lengthL >= 0                && char.IsNumber(currLine[j-lengthL]); lengthL++);
                for(lengthR = 0; j+lengthR < currLine.Length && char.IsNumber(currLine[j+lengthR]); lengthR++);

                gearRatio *= Convert.ToInt32(currLine.Substring(j-lengthL+1, lengthR + lengthL - 1));
            }
            else
            {
                string currLine = lines[i-1];

                if(char.IsNumber(lines[i-1][j-1]))
                {
                    nrCount++;

                    int lengthL;
                    for(lengthL = 1; j-lengthL >= 0 && char.IsNumber(currLine[j-lengthL]); lengthL++);
                    
                    gearRatio *= Convert.ToInt32(currLine.Substring(j-lengthL+1, lengthL-1));
                }
                if(char.IsNumber(lines[i-1][j+1]))
                {
                    nrCount++;

                    int lengthR;
                    for(lengthR = 1; j+lengthR < currLine.Length && char.IsNumber(currLine[j+lengthR]); lengthR++);

                    gearRatio *= Convert.ToInt32(currLine.Substring(j+1, lengthR-1));
                }
            }

            if(char.IsNumber(lines[i][j-1]))
            {
                nrCount++;

                int lengthL;
                for(lengthL = 1; j-lengthL > 0 && char.IsNumber(line[j-lengthL]); lengthL++);

                gearRatio *= Convert.ToInt32(line.Substring(j-lengthL+1, lengthL-1));
            }
            if(char.IsNumber(lines[i][j+1]))
            {
                nrCount++;

                int lengthR;
                for(lengthR = 1; j+lengthR < line.Length && char.IsNumber(line[j+lengthR]); lengthR++);

                gearRatio *= Convert.ToInt32(line.Substring(j+1, lengthR-1));
            }

            if(char.IsNumber(lines[i+1][j]))
            {
                nrCount++;
                string currLine = lines[i+1];

                int lengthL, lengthR;
                for(lengthL = 0; j-lengthL >= 0                && char.IsNumber(currLine[j-lengthL]); lengthL++);
                for(lengthR = 0; j+lengthR < currLine.Length && char.IsNumber(currLine[j+lengthR]); lengthR++);

                gearRatio *= Convert.ToInt32(currLine.Substring(j-lengthL+1, lengthR + lengthL - 1));
            }
            else
            {
                string currLine = lines[i+1];

                if(char.IsNumber(lines[i+1][j-1]))
                {
                    nrCount++;

                    int lengthL;
                    for(lengthL = 1; j-lengthL >= 0 && char.IsNumber(currLine[j-lengthL]); lengthL++);
                    
                    gearRatio *= Convert.ToInt32(currLine.Substring(j-lengthL+1, lengthL-1));
                }
                if(char.IsNumber(lines[i+1][j+1]))
                {
                    nrCount++;

                    int lengthR;
                    for(lengthR = 1; j+lengthR < currLine.Length && char.IsNumber(currLine[j+lengthR]); lengthR++);

                    gearRatio *= Convert.ToInt32(currLine.Substring(j+1, lengthR-1));
                }
            }

            if(nrCount == 2) sum += gearRatio;
        }
    }
}
System.Console.WriteLine(sum.ToString());
