//part one nearly worked, just need to change the type of the storage to bigint and update the challenge target day



//todays data
string[] Input = ChallengeDay6.Input.Data;

//the holding numbers, could be an array, but this is probably easier to read
System.Numerics.BigInteger Day0 = 0;
System.Numerics.BigInteger Day1 = 0;
System.Numerics.BigInteger Day2 = 0;
System.Numerics.BigInteger Day3 = 0;
System.Numerics.BigInteger Day4 = 0;
System.Numerics.BigInteger Day5 = 0;
System.Numerics.BigInteger Day6 = 0;
System.Numerics.BigInteger Day7 = 0;
System.Numerics.BigInteger Day8 = 0;
System.Numerics.BigInteger Day404 = 0;//a phantom day for when moving the fish

int Day = 0; //the current day, mostly just for the display

int DrawFish()
{
    Console.Clear();
    Console.WriteLine($"Day {Day}");
    Console.WriteLine($"Fish to replicate in x Days:");
    Console.WriteLine($"0: {Day0}");
    Console.WriteLine($"1: {Day1}");
    Console.WriteLine($"2: {Day2}");
    Console.WriteLine($"3: {Day3}");
    Console.WriteLine($"4: {Day4}");
    Console.WriteLine($"5: {Day5}");
    Console.WriteLine($"6: {Day6}");
    Console.WriteLine($"7: {Day7}");
    Console.WriteLine($"8: {Day8}");
    Console.WriteLine();
    Console.WriteLine($"Total fish: {Day0 + Day1 + Day2 + Day3 + Day4 + Day5 + Day6 + Day7 + Day8}");
    Console.WriteLine("Enter the number of days to advance(Default = 1):");
    int result = 0;
    while (result <= 0)
    {
        string text = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(text)) { result = 1; break; }
        else
        if (!int.TryParse(text, out result))
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.WriteLine();
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }
        if (result <= 0)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.WriteLine();
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }
    }
    return result;
}

void InitData()
{
    for (int i = 0; i < Input.Length; i++)
    {
        switch (Input[i])
        {
            case "0":
                Day0++;
                break;
            case "1":
                Day1++;
                break;
            case "2":
                Day2++;
                break;
            case "3":
                Day3++;
                break;
            case "4":
                Day4++;
                break;
            case "5":
                Day5++;
                break;
            case "6":
                Day6++;
                break;
            case "7":
                Day7++;
                break;
            case "8":
                Day8++;
                break;
            default:
                break;
        }
    }
}

void simulateDay()
{
    Day404 = Day0;
    Day0 = Day1;
    Day1 = Day2;
    Day2 = Day3;
    Day3 = Day4;
    Day4 = Day5;
    Day5 = Day6;
    Day6 = Day7 + Day404;
    Day7 = Day8;
    Day8 = Day404;
    Day++;
}



Console.WriteLine("Interactive(1) or Challenge(2)?(Default = 1)");
int result = 0;
while (result != 1 && result != 2)
{
    string text = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(text)) { result = 1; break; }
    if (!int.TryParse(text, out result))
    {
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        Console.WriteLine();
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
    }
    if (result != 1 && result != 2)
    {
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        Console.WriteLine();
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
    }

}
if (result == 1)
{
    InitData();
    while (true)
    {
        int TimeSkip = DrawFish();
        for (int i = 0; i < TimeSkip; i++)
        {
            simulateDay();
        }
    }
}
else if (result == 2)
{
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    InitData();
    for (int i = 0; i < 256; i++)
    {
        simulateDay();
    }
    sw.Stop();

    Console.WriteLine($"Result: {Day0 + Day1 + Day2 + Day3 + Day4 + Day5 + Day6 + Day7 + Day8} Time: {sw.Elapsed}");
    Console.ReadLine();
}
