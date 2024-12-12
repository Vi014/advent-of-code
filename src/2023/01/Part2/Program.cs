using System.Runtime.ExceptionServices;
using System.Security;
using System.Text.RegularExpressions;

int sum = 0;
foreach(string line in File.ReadAllLines("input"))
{
    bool firstDigit = false, lastDigit = false;
    for(int i = 0; !firstDigit || !lastDigit; i++)
    {
        if(!firstDigit)
        { 
            if(int.TryParse(line[i].ToString(), out int fRes)) 
            {
                sum += fRes*10;
                firstDigit = true;
            }
            else
            {
                int conv = checkText(line.Substring(i));
                if(conv != -1)
                {
                    sum += conv*10;
                    firstDigit = true;
                }
            }
        }
        if(!lastDigit)
        {
            if(int.TryParse(line[line.Length - 1 - i].ToString(), out int lRes)) 
            {
                sum += lRes;
                lastDigit = true;
            }
            else
            {
                int conv = checkText(line.Substring(line.Length - 1 - i));
                if(conv != -1)
                {
                    sum += conv;
                    lastDigit = true;
                }
            }
        }
    }
}
System.Console.WriteLine(sum.ToString());

int checkText(string inputText)
{
    if(Regex.Match(inputText, "^zero").Success)
        return 0;
    else if(Regex.Match(inputText, "^one").Success)
        return 1;
    else if(Regex.Match(inputText, "^two").Success)
        return 2;
    else if(Regex.Match(inputText, "^three").Success)
        return 3;
    else if(Regex.Match(inputText, "^four").Success)
        return 4;
    else if(Regex.Match(inputText, "^five").Success)
        return 5;
    else if(Regex.Match(inputText, "^six").Success)
        return 6;
    else if(Regex.Match(inputText, "^seven").Success)
        return 7;
    else if(Regex.Match(inputText, "^eight").Success)
        return 8;
    else if(Regex.Match(inputText, "^nine").Success)
        return 9;
    else return -1;
}