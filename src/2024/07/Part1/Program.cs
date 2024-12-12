var lines = File.ReadAllLines("input");
var numbers = new List<List<long>>();

foreach (var line in lines)
{
    var split1 = line.Split(':');
    var split2 = split1[1].Split(' ');

    var nums = new List<long>();
    nums.Add(long.Parse(split1[0]));

    for (var i = 1; i < split2.Length; i++)
    {
        nums.Add(long.Parse(split2[i]));
    }
    
    numbers.Add(nums);
}

long sum = 0;
foreach (var number in numbers)
{
    if (Calculate(number) == number[0]) sum += number[0];
}
Console.WriteLine(sum);
return;



long Calculate(List<long> inputList)
{
    if (inputList.Count == 3)
    {
        if (inputList[1] + inputList[2] == inputList[0]) return inputList[0];
        else return inputList[1] * inputList[2];
    }
    else
    {
        var listAdd = inputList.ToList();
        listAdd[1] += inputList[2];
        listAdd.RemoveAt(2);
        if (Calculate(listAdd) == inputList[0]) return inputList[0];
        
        var listMul = inputList.ToList();
        listMul[1] *= inputList[2];
        listMul.RemoveAt(2);
        return Calculate(listMul);
    }
}