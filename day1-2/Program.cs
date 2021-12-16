int[] input = day1_2.input.Input;
int result = 0;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
sw.Start();
int A = input[0]+input[1]+input[2];
for (int i = 3; i < input.Length; i++)
{
	int B = input[i-2]+input[i-1]+input[i];
	if (B > A)
	{
		result++;
	}
	A = B;
}
sw.Stop();
Console.WriteLine($"result: {result} time: {sw.Elapsed}");
Console.ReadLine();
//poke for signing3