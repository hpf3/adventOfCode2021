using Day8_2;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();


//row,display/input,segments
string[][][] Input = Day8.ChallengeInput.Demo;

//new,old
List<char[]> SegmentMap = new List<char[]>();

//code,digit
Dictionary<string,int> Digits = new Dictionary<string, int>();

//size,digit
Dictionary<int,int> DigitSizes = new Dictionary<int,int>();


void InitStage1()
{
    Digits.Add("abcefg",0);
    Digits.Add("cf",1);
    Digits.Add("acdeg",2);
    Digits.Add("acdfg",3);
    Digits.Add("bcdf",4);
    Digits.Add("abdfg",5);
    Digits.Add("abdefg",6);
    Digits.Add("acf",7);
    Digits.Add("abcdefg",8);
    Digits.Add("abcdfg",9);

    DigitSizes.Add(2, 1);
    DigitSizes.Add(4, 4);
    DigitSizes.Add(3, 7);
    DigitSizes.Add(7, 8);
}


void InitStage2(int a)
{
    SegmentMap= new List<char[]>();
    string[] sorted = Input[a][0].OrderBy(x => x.Length).ToArray();
    for (int b = 0; b < sorted.Length; b++)
    {
        if (DigitSizes.ContainsKey(sorted[b].Length))
        {
            string code = sorted[b];
            KeyValuePair<string, int> digit = Digits.First(x => (x.Value == DigitSizes[code.Length]));
            Console.WriteLine($"code: {code} == {digit.Value}");
            for (int i = 0; i < code.Length; i++)
            {

                char correct = digit.Key[i];
                char[] record = new char[] { code[i], correct };
                if (!SegmentMap.Exists(x => x[0] == record[0] || x[1] == record[1]))
                {
                    SegmentMap.Add(record);
                    Thread.Sleep(100);
                    Console.WriteLine($"{record[0]} => {record[1]}");
                }
            }
        }
    }
    FixSegmentMap();
}

void FixSegmentMap()
{
    string complete = CorrectCode("abcdefg", true);
    int missCount = complete.Where(x => x == '?').Count();
    if (missCount > 1) return;
    //else 
    if (missCount == 0) return;
    Console.WriteLine("Fixing map");
    List<char[]> newMap = new List<char[]>();
    int missing_pos = 0;
    List<char> missing = new List<char>();
    missing.AddRange(new char[] { 'a','b','c','d','e','f','g'});
    for (int i = 0;i < complete.Length; i++)
    {
        if (complete[i] == '?') missing_pos = i;
        else { newMap.Add(new char[] { complete[i], "abcdefg"[i] }); missing.Remove(complete[i]);
        }
    }
    newMap.Add(new char[] {missing.First(),"abcdefg"[missing_pos] });
    Thread.Sleep(100);
    Console.WriteLine($"{missing.First().ToString()} => {"abcdefg"[missing_pos].ToString()}");
    SegmentMap = newMap;
}




InitStage1();
int result = 0;
sw.Start();
for (int a = 0; a < Input.Length; a++)
{
    Console.WriteLine("Row "+ a);
    InitStage2(a);
    string number = "";
    for (int b = 0; b < Input[a][1].Length; b++)
    {
        for (int i = 0; i < Digits.Count; i++)
        {
            KeyValuePair<string, int> pair = Digits.ElementAt(i);
            string CorrectedCode = CorrectCode(Input[a][1][b]);
            if (pair.Key == CorrectedCode) { number += pair.Value; break; }
            //else Console.WriteLine($"{pair.Value}| {pair.Key.PadLeft(7)} || {CorrectedCode}");
        }
        if (number.Length != b + 1)
        {
            Console.WriteLine($"ERROR, row{a} ,digit{b}\n");
        }
    }
    if (string.IsNullOrEmpty(number)) { DebugOutput(a); break; }
    else
    {
        result += int.Parse(number);
        //DebugOutput(a);
    }
}
sw.Stop();
Console.WriteLine($"Result: {result} Time: {sw.Elapsed}");
Console.ReadLine();

void DebugOutput(int Row)
{
    Console.WriteLine($"Encountered Error on row {Row}");
    Console.WriteLine("Segment Map Output:");
    foreach (char[] item in SegmentMap)
    {
        Console.WriteLine($"{item[0]} == {item[1]}");
    }
    Console.WriteLine("Digits:");
    foreach (KeyValuePair<string, int> item in Digits)
    {
        Console.WriteLine($"{item.Value} {item.Key.PadLeft(7)} | {CorrectCode(item.Key,true)}");
    }
    Console.WriteLine("Input:");
    for (int b = 0; b < Input[Row][1].Length; b++)
    {
        Console.WriteLine($"{Input[Row][1][b].PadLeft(7)} | {CorrectCode(Input[Row][1][b])}");
    }
    Console.WriteLine("Long Input:");
    for (int b = 0; b < Input[Row][0].Length; b++)
    {
        Console.WriteLine($"{Input[Row][0][b].PadLeft(7)} | {CorrectCode(Input[Row][0][b])}");
    }
    string eight = CorrectCode("abcdefg", true);
    Console.WriteLine();
    Console.WriteLine($" {new string(eight[0], 4)} ");
    Console.WriteLine($"{eight[1]}    {eight[2]}");
    Console.WriteLine($"{eight[1]}    {eight[2]}");
    Console.WriteLine($" {new string(eight[3], 4)} ");
    Console.WriteLine($"{eight[4]}    {eight[5]}");
    Console.WriteLine($"{eight[4]}    {eight[5]}");
    Console.WriteLine($" {new string(eight[6], 4)} ");
}

char CorrectSegment(char input,bool reverse=false)
{
    char result = '?';
    int mode = 0;
    if (reverse) mode = 1;
if (SegmentMap.Exists(x => x[mode] == input))
    result = SegmentMap.Find(x => x[mode] == input)[1-mode];
return result;
}

string CorrectCode(string code, bool reverse = false)
{
    char[] result = new char[code.Length];
    for (int i = 0; i < code.Length; i++)
    {
        result[i] =CorrectSegment(code[i],reverse);
    }
    if (!reverse) return new string(result).Sort();
    return new string(result);
}

namespace Day8_2
{
    public static class Extender
    {
        public static string Sort(this string input)
        {
            return new string(input.OrderBy(x => x).ToArray());
        }
    }
}