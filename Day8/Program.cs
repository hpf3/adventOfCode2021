System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();


//row,display/input,segments
string[][][] Input = Day8.ChallengeInput.Data;

//digit,Size
Dictionary<int,int> DigitSizes = new Dictionary<int,int>();

void Init()
{
    DigitSizes.Add(1,2);
    DigitSizes.Add(4,4);
    DigitSizes.Add(7,3);
    DigitSizes.Add(8,7);
}

int result = 0;
sw.Start();
Init();
for (int a = 0; a < Input.Length; a++)
{
    for (int b = 0; b < 4; b++)
    {
        if (DigitSizes.ContainsValue(Input[a][1][b].Length))
            result++;
    }
}
sw.Stop();
Console.WriteLine($"Result: {result} Time: {sw.Elapsed}");
Console.ReadLine();
