using Day5;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
Segment[] input = Input.Data;
Console.WriteLine($"input has {input.Length} segments");
Matrix matrix = new Matrix();

sw.Start();
for (int i = 0; i < input.Length; i++)
{
    if (!input[i].isAngled())
    {
        foreach (int[] item in input[i].BresenhamPoints())
        {
            matrix[item[0], item[1]] += 1;
        }
    }
}
int Result = 0;
Console.WriteLine($"{matrix.sparse_matrix.Count} points recorded");
foreach (KeyValuePair<Tuple<int, int>, int> item in matrix.sparse_matrix)
{
    //Console.WriteLine($"({item.Key.Item1},{item.Key.Item2}) Count: {item.Value}");
    if (item.Value >= 2)
    {
        Result++;
    }
}
sw.Stop();
Console.WriteLine($"Result: {Result} Time: {sw.Elapsed}");
Console.ReadLine();




namespace Day5
{
    public class Matrix
    {
        public Dictionary<Tuple<int,int>, int> sparse_matrix = new Dictionary<Tuple<int, int>, int>();
        public int this[int x, int y] { get => GetData(x, y); set => SetData(x, y, value); }
        private int GetData(int x, int y)
        {
            Tuple<int,int> point = new Tuple<int, int>(x,y);
            if (sparse_matrix.ContainsKey(point)) return sparse_matrix[point];
            else return 0;
        }
        private void SetData(int x, int y, int Data)
        {
            Tuple<int, int> point = new Tuple<int, int>(x, y);
            //Console.WriteLine($"setting ({x},{y}) from {GetData(x,y)} to {Data}");
            sparse_matrix[point] = Data;
        }
    }
}