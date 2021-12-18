string[] Input = Day7.ChallengeInput.Data;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

sw.Start();
int[] crabs = new int[Input.Length];

int Max = 0;
int Min = 0;
for (int i = 0; i < Input.Length; i++)
{
    crabs[i] = int.Parse(Input[i]);
    if (crabs[i] > Max) Max = crabs[i];
    if (crabs[i] < Min) Min = crabs[i];
}

int result = int.MaxValue;
for (int a = Min; a <= Max; a++)
{
    int score = 0;
    for (int b = 0; b < crabs.Length; b++)
    {
        score += Math.Max(a, crabs[b]) - Math.Min(a, crabs[b]);
    }
    if (score < result) 
        result = score;
}
sw.Stop();
Console.WriteLine($"Result: {result} Time: {sw.Elapsed}");
Console.ReadLine();
