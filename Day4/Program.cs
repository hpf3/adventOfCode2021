Day4.Bingo Input = Day4.Input.Data;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

bool Test(int[,] card, List<int> marked)
{
    bool LineMatch = false;
    //rows
    for (int y = 0; y < card.GetLength(1); y++)
    {
        LineMatch = false;
        for (int x = 0; x < card.GetLength(0); x++)
        {
            bool NumbMatch = false;
            for (int i = 0; i < marked.Count; i++)
            {
                NumbMatch = card[x,y] == marked[i];
                if (NumbMatch) break;
            }
            LineMatch = NumbMatch;
            if (!LineMatch) break;
        }
        if (LineMatch) return true;
    }
    //collumbs
    for (int x = 0; x < card.GetLength(0); x++)
    {
        LineMatch = false;
        for (int y = 0; y < card.GetLength(1); y++)
        {
            bool NumbMatch = false;
            for (int i = 0; i < marked.Count; i++)
            {
                NumbMatch = card[x, y] == marked[i];
                if (NumbMatch) break;
            }
            LineMatch = NumbMatch;
            if (!LineMatch) break;
        }
        if (LineMatch) return true;
    }
    //diagonals
    if (card.GetLength(0) != card.GetLength(1)) return false;
    //+x+y
    LineMatch = false;
    for (int a = 0; a < card.GetLength(0); a++)
    {
        bool NumbMatch = false;

        for (int i = 0; i < marked.Count; i++)
        {
            NumbMatch = card[a, a] == marked[i];
            if (NumbMatch) break;
        }

        LineMatch = NumbMatch;
        if (!LineMatch) break;
    }
    if (LineMatch) return true;
    //-x-y
    for (int a = card.GetLength(0) - 1; a >= 0; a--)
    {
        bool NumbMatch = false;

        for (int i = 0; i < marked.Count; i++)
        {
            NumbMatch = card[a, a] == marked[i];
            if (NumbMatch) break;
        }

        LineMatch = NumbMatch;
        if (!LineMatch) break;
    }
    if (LineMatch) return true;
    return false;
}

int Score(int[,] card, List<int> marked)
{
    int unMarked = 0;

    for (int y = 0; y < card.GetLength(1); y++)
    {
        for (int x = 0; x < card.GetLength(0); x++)
        {
            bool NumbMatch = false;
            for (int i = 0; i < marked.Count; i++)
            {
                NumbMatch = card[x, y] == marked[i];
                if (NumbMatch) break;
            }
            if (!NumbMatch) unMarked+= card[x, y];
        }
    }
    return unMarked*marked[marked.Count-1];
}

int Run()
{
    List<int> markedNumbers = new List<int>();
    for (int i = 0; i < Input.WinList.Length; i++)
    {
        markedNumbers.Add(Input.WinList[i]);
        foreach (int[,] card in Input.Cards)
        {
            if (Test(card, markedNumbers)) return Score(card, markedNumbers);
        }
    }
    return 0;
}

sw.Start();
int Result = Run();
sw.Stop();


Console.WriteLine($"Result: {Result} Time: {sw.Elapsed}");
Console.ReadLine();