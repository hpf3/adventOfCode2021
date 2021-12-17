System.Collections.BitArray[] Input = Day3.Input.Data;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

static int toint(System.Collections.BitArray array)
{
    int result = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i]) result += Convert.ToInt32(Math.Pow(2, array.Length - i - 1));
    }
    return result;
}

int OxygenGenerator()
{
    List<System.Collections.BitArray> Working = new List<System.Collections.BitArray>(Input);
    int bitlength = Working[0].Count;
    for (int p = 0; p < bitlength; p++)
    {
        int trueCount = 0;
        int falseCount = 0;
        for (int i = 0; i < Working.Count; i++)
        {
            if (Working[i][p]) trueCount++;
            else falseCount++;
        }
        bool keepBit = trueCount >= falseCount;



        if (Working.Count > 1)
            Working.RemoveAll(x =>
            {
                return x[p] != keepBit;
        });

    }
    return toint(Working[0]);
}
int Co2Scrubber()
{
    List<System.Collections.BitArray> Working = new List<System.Collections.BitArray>(Input);
    int bitlength = Working[0].Count;
    for (int p = 0; p < bitlength; p++)
    {
        int trueCount = 0;
        int falseCount = 0;
        for (int i = 0; i < Working.Count; i++)
        {
            if (Working[i][p]) trueCount++;
            else falseCount++;
        }
        bool throwBit = trueCount >= falseCount;


        if (Working.Count>1)
        Working.RemoveAll(x =>
        {
            return x[p] == throwBit;
        });

    }
    return toint(Working[0]);
}

sw.Start();
int Result = OxygenGenerator() * Co2Scrubber();
sw.Stop();

Console.WriteLine($"Result:{Result} Time:{sw.Elapsed}");
Console.ReadLine();