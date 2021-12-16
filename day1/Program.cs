int[] input = new int[] {
199,
200,
208,
210,
200,
207,
240,
269,
260,
263
};
int result = 0;
for (int i = 1; i < input.Length; i++)
			{
	if (input[i] > input[i-1])
	{
		result++;
	}
			}
Console.WriteLine(result);
Console.ReadLine();