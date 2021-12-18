using Day5;
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
Segment[] input = Input.Data;
List<Segment> filtered = new List<Segment>();
Console.WriteLine($"input has {input.Length} segments");
Matrix matrix = new Matrix();

int xmin = 0;
int xmax = 0;
int ymin = 0;
int ymax = 0;
sw.Start();

//remembering how to properly get the points on a line is failing, time for brute force.
for (int i = 0; i < input.Length; i++)
{
    if ((!input[i].isAngled()) || (Math.Abs(input[i].GetAngle())==45))
    {
        if (input[i].A[0] > xmax) xmax = input[i].A[0];
        if (input[i].A[0] < xmin) xmin = input[i].A[0];
        if (input[i].A[1] > ymax) ymax = input[i].A[1];
        if (input[i].A[1] < ymin) ymin = input[i].A[1];
        if (input[i].B[0] > xmax) xmax = input[i].B[0];
        if (input[i].B[0] < xmin) xmin = input[i].B[0];
        if (input[i].B[1] > ymax) ymax = input[i].B[1];
        if (input[i].B[1] < ymin) ymin = input[i].B[1];
        filtered.Add(input[i]);
    }
}
Console.WriteLine($"testing {(xmax - xmin) * (ymax - ymin)} points, please wait ......");
for (int x = xmin; x <= xmax; x++)
{
    for (int y = ymin; y <= ymax; y++)
    {
        foreach (Segment line in filtered)
        {
            if (Day5_2.isInbetween(line.A,new int[]{x,y},line.B)) matrix[x, y] += 1;
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
if((xmax-xmin)<=20 && (ymax-ymin)<=20)
matrix.Plot();
Console.ReadLine();



namespace Day5
{
    public static class Day5_2
    {
        public static int GetAngle(this Segment segment)
        {
            float xDiff = Math.Abs(segment.B[0] - segment.A[0]);
            float yDiff = Math.Abs(segment.B[1] - segment.A[1]);
            int result = (int)Math.Round(Math.Atan2(yDiff, xDiff) * (180 / Math.PI));
            //Console.WriteLine($"{segment.toString()} Angle: {result}" );
            return result;
        }

        public static List<int[]> GetPoints(this Segment segment)
        {
            List<int[]> points = new List<int[]>();

            if (!segment.isAngled()) return segment.BresenhamPoints();

            int xc = -1;
            int yc = -1;
            if (segment.A[0] < segment.B[0]) xc = 1;
            if (segment.A[1] < segment.B[1]) yc = 1;
            int x=segment.A[0];
            int y=segment.A[1];
            do
            {
                points.Add(new int[] { x, y });
                x += xc;
                y += yc;
            } while (x != segment.B[0]);

            return points;
        }

        public static string toString(this Segment segment)
        {
            return $"({segment.A[0]},{segment.A[1]}) -> ({segment.B[0]},{segment.B[1]})";
        }

        public static void Plot(this Matrix data)
        {
            int xmin = 0;
            int xmax = 0;
            int ymin = 0;
            int ymax = 0;
            foreach (KeyValuePair<Tuple<int, int>, int> item in data.sparse_matrix)
            {
                if (item.Key.Item1 > xmax) xmax = item.Key.Item1;
                if (item.Key.Item1 < xmin) xmin = item.Key.Item1;
                if (item.Key.Item2 > ymax) ymax = item.Key.Item2;
                if (item.Key.Item2 < ymin) ymin = item.Key.Item2;
            }
            Console.WriteLine();
            for (int y = ymin; y <= ymax; y++)
            {
                for (int x = xmin; x <= xmax; x++)
                {
                    int val = data[x, y];
                    if (val != 0) Console.Write(val);
                    else Console.Write('.');
                    Console.Write(' ');
                }
                Console.WriteLine();
            }


        }
        public static bool isInbetween(int[] a,int[] c, int[] b)
        {
            if (c == a || c == b) return true;
            
            
            int minx = Math.Min(a[0], b[0]);
            int maxx = Math.Max(a[0], b[0]);
            int miny = Math.Min(a[1], b[1]);
            int maxy = Math.Max(a[1], b[1]);

            if ((c[0] < minx) || (c[1] < miny) || (c[0] > maxx || c[1] > maxy)) return false;

            int r = a[0] * (b[1] - c[1]) +
                b[0] * (c[1] - a[1]) +
                c[0] * (a[1] - b[1]);
            return (r== 0);
        }
    }
}