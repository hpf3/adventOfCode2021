Day4.Bingo Input = Day4.Input.Data;
List<int[,]> matchedCards = new List<int[,]>();
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

int Test(int[,] card, List<int> marked)
{
    int Lines = 0;
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
                NumbMatch = card[x, y] == marked[i];
                if (NumbMatch) break;
            }
            LineMatch = NumbMatch;
            if (!LineMatch) break;
        }
        if (LineMatch) Lines++;
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
        if (LineMatch) Lines++;
    }
    if (Lines > 1)
    {
        Console.WriteLine("ERROR: multiple matches");
        DrawMatches(card, marked);
    }
if (Lines > 0) matchedCards.Add(card);
    return Lines;
}

void DrawMatches(int[,] card, List<int> marked)
{
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
            if (NumbMatch && card[x,y] < 10) Console.Write(" ");
            if (NumbMatch) Console.Write(card[x, y]);
            else Console.Write("  ");
            Console.Write(" ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine($"Last Match: {marked.LastOrDefault(404)}");
    int count = 0; foreach (var item in matchedCards) { if (item == card) count++; }
    Console.WriteLine(String.Format( "Times Won: {0}", count));
    Console.WriteLine($"Total Wins: {matchedCards.Count}");
    Console.WriteLine();
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
            if (!NumbMatch) unMarked += card[x, y];
        }
    }
    return unMarked * marked[marked.Count - 1];
}

int Run()
{
    List<int> markedNumbers = new List<int>();
    int[,] LastWin = Input.Cards[0];
    List<int> LastWinMarked = new List<int>();
    for (int i = 0; i < Input.WinList.Length; i++)
    {
        bool repeat = false;
        do//forgetting to check for multiple wins per number leads to bad times
        {
        markedNumbers.Add(Input.WinList[i]);
            int[,]? WinningCard= null;
            foreach (int[,] card in Input.Cards)
            {
                if (Test(card, markedNumbers)>0)
                {
                    WinningCard = card;
                    break;
                }
            }
        if ((Input.Cards.Count <= 1) && (WinningCard != null))
        {
            return Score(WinningCard, markedNumbers);
        }
        if (WinningCard != null)
        {
            LastWin = WinningCard;
            LastWinMarked.Clear();
            LastWinMarked.AddRange(markedNumbers);
            Input.Cards.Remove(WinningCard);
                repeat = true;
        }
        else repeat = false;

        } while (repeat);


    }
    return Score(LastWin, LastWinMarked);
}

sw.Start();
int Result = Run();
sw.Stop();


Console.WriteLine($"Result: {Result} Time: {sw.Elapsed}");
Console.ReadLine();