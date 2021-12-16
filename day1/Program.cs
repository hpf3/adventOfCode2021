int[] input = day1.input.Input;
int result = 0;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
sw.Start();
for (int i = 1; i < input.Length; i++)
			{
	if (input[i] > input[i-1])
	{
		result++;
	}
			}
sw.Stop();
Console.WriteLine($"result: {result} time: {sw.Elapsed}");
Console.ReadLine();