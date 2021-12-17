System.Collections.BitArray[] Input = Day3.Input.Data;
int[] OneCount = new int[Input.Length];
int[] ZeroCount = new int[Input.Length];
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

static int toint(System.Collections.BitArray array)
{
    int result = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i]) result += Convert.ToInt32(Math.Pow(2, array.Length-i-1));
    }
    return result;
}

sw.Start();
for (int i = 0; i < Input.Length; i++)
{
    for (int p = 0; p < Input[0].Length; p++)
    {
        if (Input[i][p])
        {
            OneCount[p]++;
        }
        else
        {
            ZeroCount[p]++;
        }
    }
}
System.Collections.BitArray BitArray = new System.Collections.BitArray(Input[0].Length);
for (int i = 0; i < BitArray.Length; i++)
{
    BitArray[i] = OneCount[i] > ZeroCount[i];
}
int Gamma = toint(BitArray);
int Epsilon = toint(BitArray.Not());
int Result = Gamma * Epsilon;
sw.Stop();

Console.WriteLine($"Result: {Result} Time: {sw.Elapsed}");
Console.ReadLine();