List<KeyValuePair<string, int>> input = day2.Input.Data;
int X = 0;
int Y = 0;
int Aim = 0;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
sw.Start();
foreach (KeyValuePair<string, int> item in input)
{
    switch (item.Key)
    {
        case "forward":
            X += item.Value;
            Y += Aim*item.Value;
            break;
        case "up":
            Aim -= item.Value;
            break;
        case "down":
            Aim += item.Value;
            break;
        default:
            break;
    }
}
int Result = X * Y;
sw.Stop();
Console.WriteLine($"result: {Result} Time:{sw.Elapsed}");
Console.ReadLine();