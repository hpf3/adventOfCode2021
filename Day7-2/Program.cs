string[] Input = Day7.ChallengeInput.Data;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

sw.Start();
int[] crabs = new int[Input.Length];

int Max = 0;
int Min = 0;
//convert the strings and set min&max
for (int i = 0; i < Input.Length; i++)
{
    crabs[i] = int.Parse(Input[i]);
    if (crabs[i] > Max) Max = crabs[i];
    if (crabs[i] < Min) Min = crabs[i];
}

int result = int.MaxValue;
int pos = 0;
for (int a = Min; a <= Max; a++)
{
    int score = 0;

    for (int b = 0; b < crabs.Length; b++)
    {
        int d = Math.Max(a, crabs[b]) - Math.Min(a, crabs[b]);
        double tmp = (((d - 1d) / 2d + 1d) * d);//by the power of math smart siblings
        score += (int)tmp;
    }
    if (score < result)
    {
        pos = a;
        result = score;
    }
}
sw.Stop();
Console.WriteLine($"Pos:{pos}");
Console.WriteLine($"Result: {result} Time: {sw.Elapsed}");
Console.ReadLine();
